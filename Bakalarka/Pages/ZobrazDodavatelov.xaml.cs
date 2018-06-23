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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Bakalarka.Triedy;
using Bakalarka.Windows;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Bakalarka.Pages
{
    /// <summary>
    /// Interaction logic for ZobrazDodavatelov.xaml
    /// </summary>
    public partial class ZobrazDodavatelov : Page, INotifyPropertyChanged
    {
        MainWindow mainWindow;
        List<TovaryNaZobrazenie> tovaryNaZobrazenieList;


        public ZobrazDodavatelov(MainWindow pMainWindow)
        {
            InitializeComponent();
            tovaryNaZobrazenieList = new List<TovaryNaZobrazenie>();
            mainWindow = pMainWindow;
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Dodavatel_Click(object sender, RoutedEventArgs e)
        {
            var dodavatel = ((sender as DataGridCell).DataContext as DataRowView);
            var dodavatelID = dodavatel.Row.ItemArray[2];

            TovaryNaZobrazenie tovaryVObjednavke = new TovaryNaZobrazenie(mainWindow,  (string)dodavatelID + "");
            tovaryNaZobrazenieList.Add(tovaryVObjednavke);
            tovaryVObjednavke.NeZobrazit = true;

            try
            {
                using (OracleCommand cmd = new OracleCommand("select tovarID,datumDorucenia,DatumPrijatiaNaSklad," +
                    "Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = tovar.dodavatelID) join prijemca using (prijemcaID) " +
                    "where Dodavatel.dodavatelID = " + "'" + dodavatelID + "'"
                    , mainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        tovaryVObjednavke.vsetkyTovaryGrid.DataContext = dataTable; ;
                        tovaryVObjednavke.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var dodavatelID = (dodavateliaGrid.SelectedItem as DataRowView).Row.ItemArray[2];
            var dialogResult = Upraveny_MessageBox.Show("Odstrániť dodávateľa", "Naozaj chceš odstrániť dodávateľa a všetky jeho objednávky? ICO: " + dodavatelID + " ?", MessageBoxButton.YesNo, Bakalarka.Windows.MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("delete from dodavatel where dodavatelID = " + "'" + dodavatelID + "'", mainWindow.Databaza.Connection);
                    cmd.ExecuteNonQuery();
                    Upraveny_MessageBox.Show("Dodávateľ bol úspešne odstránený");
                    mainWindow.Databaza.zobrazDodavatelov(this);
                    mainWindow.nacitajDnesPrichadzajuceObjednavky();
                }
                catch (Exception ex)
                {
                    Upraveny_MessageBox.Show(ex.Message);
                }
            }
        }

        public void vypniOkna()
        {
            foreach (TovaryNaZobrazenie tovaryNaZobrazenie in tovaryNaZobrazenieList)
            {
                tovaryNaZobrazenie.Close();
            }
        }
    }
}
