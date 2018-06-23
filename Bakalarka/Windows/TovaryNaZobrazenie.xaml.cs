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
using Bakalarka.Triedy;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Bakalarka.Triedy.Databaza;

namespace Bakalarka.Windows
{
    /// <summary>
    /// Interaction logic for TovaryVObjednavke.xaml
    /// </summary>
    public partial class TovaryNaZobrazenie : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        MainWindow mainWindow;
        List<String> tovaryNaPrijatie;
        string objednavkaID;

        string isMaxed = "[ ]";
        bool neZobrazit;
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

        public bool NeZobrazit
        {
            get => neZobrazit; set
            {
                if (neZobrazit != value)
                {
                    neZobrazit = value;
                    OnPropertyChanged("NeZobrazit");
                }
            }
        }

         string skuska;

        public string Skuska
        {
            get => skuska; set
            {
                if (skuska != value)
                {
                    skuska = value;
                    OnPropertyChanged("Skuska");
                }
            }
        }
        public TovaryNaZobrazenie(MainWindow pMainWindow, string pObjednavkaID)
        {

            InitializeComponent();
            DataContext = this;
            mainWindow = pMainWindow;
            tovaryNaPrijatie = new List<String>();
            objednavkaID = pObjednavkaID;
            Skuska = "Ahoj";
        }

        public TovaryNaZobrazenie(MainWindow pMainWindow)
        {

            InitializeComponent();
            mainWindow = pMainWindow;
            tovaryNaPrijatie = new List<String>();       
            DataContext = this;
            Skuska = "Ahoj";
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void PrijatCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var objednavka = (((sender as System.Windows.Controls.CheckBox).DataContext) as DataRowView).Row;
            tovaryNaPrijatie.Add((String)objednavka.ItemArray[0]);

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var objednavka = (((sender as System.Windows.Controls.CheckBox).DataContext) as DataRowView).Row;
            tovaryNaPrijatie.Remove((String)objednavka.ItemArray[0]);
        }

        public void reload()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select tovarID,datumDorucenia,DatumPrijatiaNaSklad," +
                    "Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) " +
                    "where objednavkaID = " + "'" + objednavkaID + "'"
                    , mainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        vsetkyTovaryGrid.DataContext = dataTable;
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

        private void PotvrdPrijatie_Click(object sender, RoutedEventArgs e)
        {
            foreach (var tovarID in tovaryNaPrijatie)
            {
                try
                {
                    var sql = "update tovar set prijaty = 1, datumPrijatiaNaSklad = " + "'" + DateTime.Today.ToShortDateString() + "'" +
                        " where tovarID = " + "'" + tovarID + "'";

                    using (OracleCommand cmd = new OracleCommand(sql, mainWindow.Databaza.Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    sql = "update objednavka set vybavena = " +
                        "CASE WHEN(select count(*) from tovar where tovar.objednavkaID = objednavka.objednavkaID ) = " +
                        "(select count(*) from tovar where tovar.objednavkaID = objednavka.objednavkaID and tovar.prijaty = 1 ) then 'V'" +
                        "when(select count(*) from tovar where tovar.objednavkaID = objednavka.objednavkaID and tovar.prijaty = 1) > 0" +
                        "then 'C' else 'N' end where objednavkaID = (select objednavkaID from tovar join objednavka using(objednavkaID)" +
                        " where tovarID = " + "'" + tovarID + "'" + ")";

                    using (OracleCommand cmd = new OracleCommand(sql, mainWindow.Databaza.Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    reload();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            reload();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            vsetkyTovaryGrid.Width = this.Width;
            vsetkyTovaryGrid.Height = this.Height - 150;
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
    }
}
