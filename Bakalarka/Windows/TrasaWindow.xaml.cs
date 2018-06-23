using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using Bakalarka.Mapa.Pages;
using Bakalarka.Mapa;

namespace Bakalarka.Windows
{
    /// <summary>
    /// Interaction logic for TrasaWindow.xaml
    /// </summary>
    public partial class TrasaWindow : Window, INotifyPropertyChanged
    {
        MainWindow mainWindow;
        public event PropertyChangedEventHandler PropertyChanged;
        List<String> doruceneTovary;
        DateTime datumTrasy;
        DataTable trasyDataTable;
        DataTable vozidlaDataTable;
        DataTable tovaryDataTable;
        Mapa_Window mapa_Window;


        string isMaxed = "[ ]";
        public string IsMaxed
        {
            get => isMaxed; set
            {
                if (isMaxed != value)
                {
                    isMaxed = value;
                    OnPropertyChanged("IsMaxed");
                }
            }
        }
        public Mapa_Window Mapa_Window { get => mapa_Window; set => mapa_Window = value; }

        public TrasaWindow(MainWindow pmainWindow, DateTime dateTime)
        {
            InitializeComponent();
            DataContext = this;
            mainWindow = pmainWindow;
            datumTrasy = dateTime;
            DateTimePicker_VybratyDatum.SelectedDate = dateTime;
            Mapa_Window = pmainWindow.Mapa_Window;
            StackPanelTovary.Height = this.Height;
            StackPanelTovary.Width = this.Width - StackPanelVozidla.Width;
            doruceneTovary = new List<string>();

            tovaryDataTable = new DataTable();
            vozidlaDataTable = new DataTable();
            trasyDataTable = new DataTable();
            NacitajVozidla();

            System.Threading.Thread thread = new System.Threading.Thread(zobrazTrasy);
            thread.Start(dateTime);
             
        }

        public void NacitajVozidla()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select trasaID from trasa " +
                  " where datumTrasy = '" + datumTrasy.ToShortDateString() + "'"
                 , mainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        trasyDataTable.Load(reader);
                    }
                }
                foreach (DataRow trasaID in trasyDataTable.Rows)
                {
                    using (OracleCommand cmd = new OracleCommand("select DISTINCT vozidlo.vozidloID, trasaID from vozidlo " +
                        "join tovar on(vozidlo.vozidloID = tovar.vozidloID) join trasa using (trasaID)  " +
                        "where datumTrasy = '" + datumTrasy.ToShortDateString() + "' and trasaID = " + trasaID.ItemArray[0]
                     , mainWindow.Databaza.Connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            vozidlaDataTable.Load(reader);
                        }
                    }
                }
                ZoznamAut.DataContext = vozidlaDataTable;
            }
            catch (Exception e)
            {
                Upraveny_MessageBox.Show(e.ToString());
            }
        }
        public void reload()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select poradieVTrase,tovarID,datumDorucenia,DatumPrijatiaNaSklad," +
                "Hmotnost,dlzka,sirka,vyska, tovar.vozidloID, " +
                    "Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny, " +
                    "objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    "Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) join trasa on (trasa.trasaID = tovar.trasaID) " +
                    "where tovar.vozidloID = '" + ((DataRowView)ZoznamAut.SelectedItem).Row.ItemArray[0] + "' and trasa.datumTrasy = '"
                    + datumTrasy.ToShortDateString() + "' and trasa.trasaID = " + ((DataRowView)ZoznamAut.SelectedItem).Row.ItemArray[1] + "order by poradieVTrase"
                    , mainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        tovaryDataTable.Clear();
                        tovaryDataTable.Load(reader);

                        vsetkyTovaryGrid.DataContext = tovaryDataTable;
                        vsetkyTovaryGrid.Items.Refresh();
                    }
                }

                mainWindow.nacitajDnesPrichadzajuceObjednavky();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Uloz_Click(object sender, RoutedEventArgs e)
        {
            var sql = "";
            foreach (var tovarID in doruceneTovary)
            {
                try
                {
                    sql = "update tovar set doruceny = 1, datumDorucenia = " + "'" + DateTime.Today.ToShortDateString() + "'" +
                        " where tovarID = " + "'" + tovarID + "'";

                    using (OracleCommand cmd = new OracleCommand(sql, mainWindow.Databaza.Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }


                }
                catch (Exception ex)
                {
                    Upraveny_MessageBox.Show(ex.Message);
                }
            }

            sql = "update vozidlo set polohaVozidla = null " +
                       " where vozidloID = " + "'" + ((DataRowView)ZoznamAut.SelectedItem).Row.ItemArray[0] + "'";

            using (OracleCommand cmd = new OracleCommand(sql, mainWindow.Databaza.Connection))
            {
                cmd.ExecuteNonQuery();
            }

            reload();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var tovar = (((sender as System.Windows.Controls.CheckBox).DataContext) as DataRowView).Row;
            doruceneTovary.Remove((String)tovar.ItemArray[1]);
        }

        private void PrijatCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var tovar = (((sender as System.Windows.Controls.CheckBox).DataContext) as DataRowView).Row;
            doruceneTovary.Add((String)tovar.ItemArray[1]);
        }

        private void ZoznamAut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var pom = (DataRowView)ZoznamAut.SelectedItem;
            doruceneTovary.Clear();

            if (pom != null)
            {
                tovaryDataTable.Clear();
                using (OracleCommand cmd = new OracleCommand("select poradieVTrase,tovarID,datumDorucenia,DatumPrijatiaNaSklad," +
                    "Hmotnost,dlzka,sirka,vyska, tovar.vozidloID, " +
                        "Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny, " +
                        "objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                        "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                        "Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda from tovar join objednavka using (objednavkaID) join dodavatel " +
                        "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) join trasa on (trasa.trasaID = tovar.trasaID) " +
                        "where tovar.vozidloID = '" + pom.Row.ItemArray[0] + "' and trasa.datumTrasy = '" + datumTrasy.ToShortDateString() +
                        "' and trasa.trasaID = " + pom.Row.ItemArray[1] + "order by poradieVTrase"

              , mainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        tovaryDataTable.Load(reader);
                        vsetkyTovaryGrid.DataContext = tovaryDataTable;
                    }
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            StackPanelTovary.Height = this.Height;
            StackPanelTovary.Width = this.Width - StackPanelVozidla.Width;
        }


        public void zobrazTrasy(object pdateTime)
        {
          
            DateTime dateTime = (DateTime)pdateTime;
            var cesty = new List<List<String>>();
            trasyDataTable = new DataTable();
            try
            {
                using (OracleCommand cmd = new OracleCommand("select trasaID from trasa " +
                  " where datumTrasy = '" + dateTime.ToShortDateString() + "'"
             , mainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        trasyDataTable.Load(reader);
                    }
                }

                foreach (DataRow trasaID in trasyDataTable.Rows)
                {

                    DataTable dataTable = new DataTable();
                    using (OracleCommand cmd = new OracleCommand("select adresa, tovar.vozidloID from tovar " +
                        " join trasa using (trasaID) join prijemca using(prijemcaID) " +
                        " where datumTrasy = '" + dateTime.ToShortDateString() + "' and trasaID = + " + trasaID.ItemArray[0] + " order by poradieVTrase "
                  , mainWindow.Databaza.Connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    var zoznamAdries = new List<String>();

                    if (dataTable.Rows.Count != 0)
                    {
                        zoznamAdries.Add((String)dataTable.Rows[0].ItemArray[1]);
                        zoznamAdries.Add("Chynorany");

                        foreach (DataRow row in dataTable.Rows)
                        {
                            zoznamAdries.Add((String)row.ItemArray[0] + ", Slovakia");
                        }

                        zoznamAdries = zoznamAdries.GroupBy(adresa => adresa).Select(group => group.First()).ToList();
                        cesty.Add(zoznamAdries);
                    }
                }

                LoadingPage loadingPage = mainWindow.Mapa_Window.LoadingPage;

                Mapa_Window.Dispatcher.Invoke(() =>
                {                    
                    Mapa_Window.Show();
                    Mapa_Window.HlavnyFrame.Content = loadingPage;
                    loadingPage.ProgressBar.Value = 0;
                    loadingPage.Faza.Text = "";
                    loadingPage.TextStatus.Text = "Zobrazujem trasy na mape";
                });
                System.ConsoleColor[] consoleColors = (System.ConsoleColor[])Enum.GetValues(typeof(System.ConsoleColor));


                for (int i = 0; i < cesty.Count; i++)
                {
                    String vozidloID = cesty[i][0];
                    cesty[i].RemoveAt(0);
                    var farba = System.Drawing.Color.FromName(consoleColors[i].ToString());
                    Mapa_Window.pridajCesty(cesty[i][0], cesty[i][0], cesty[i], farba, 5,
                       vozidloID + " [ " + farba.Name + " ]", loadingPage, cesty.Count);
                }

                Mapa_Window.Dispatcher.Invoke(() =>
                {
                    Mapa_Window.HlavnyFrame.Content = Mapa_Window.MapaPage;
                });
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.ToString());
                });
            }
        }
        System.Threading.Thread zobrazTrasyVlakno;
        private void ButtPotvrdDatum_Click(object sender, RoutedEventArgs e)
        {
            datumTrasy = DateTimePicker_VybratyDatum.SelectedDate.Value;
            trasyDataTable.Clear();
            vozidlaDataTable.Clear();
            tovaryDataTable.Clear();
            NacitajVozidla();

            Mapa_Window.Dispatcher.Invoke(() =>
            {
                Mapa_Window.Routes.Clear();
                Mapa_Window.Markers.Clear();
                Mapa_Window.ListBoxTrasy.Items.Clear();
            });      
            
            zobrazTrasyVlakno = new System.Threading.Thread(zobrazTrasy);
            zobrazTrasyVlakno.Start(datumTrasy);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {

            if (this.WindowState != System.Windows.WindowState.Maximized)
            {
                IsMaxed = "[ ]";
            }
            else
            {
                IsMaxed = "[]]";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            zobrazTrasyVlakno.Abort();
        }
    }
}
