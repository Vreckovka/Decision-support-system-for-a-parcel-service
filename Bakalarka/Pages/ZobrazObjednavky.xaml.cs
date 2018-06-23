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
using Bakalarka.Triedy.Databaza;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Bakalarka.Pages
{
    /// <summary>
    /// Interaction logic for ZobrazTovarNaPrijatie.xaml
    /// </summary>
    public partial class ZobrazObjednavkyPage : Page, INotifyPropertyChanged
    {
        MainWindow mainWindow;
        Databaza databaza;
        List<TovaryNaZobrazenie> tovaryNaZobrazenieList;

        public ZobrazObjednavkyPage(MainWindow pMainWindow, Databaza pdatabaza)
        {
            InitializeComponent();
            mainWindow = pMainWindow;
            DataContext = this;
            databaza = pdatabaza;
            tovaryNaZobrazenieList = new List<TovaryNaZobrazenie>();
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

        private void Objednavka_Click(object sender, RoutedEventArgs e)
        {
            var objednavka = ((sender as DataGridCell).DataContext as DataRowView);
            var objednavkaID = objednavka.Row.ItemArray[0];

           
            TovaryNaZobrazenie tovaryVObjednavke = new TovaryNaZobrazenie(mainWindow,  (string)objednavkaID);
            tovaryNaZobrazenieList.Add(tovaryVObjednavke);

            try
            {
                using (OracleCommand cmd = new OracleCommand("select tovarID,datumDorucenia,DatumPrijatiaNaSklad," +
                    "Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) " +
                    "where objednavkaID = " + "'" + objednavkaID + "'"
                    , databaza.Connection))
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
            var objednavkaID = (vsetkyObjednavky.SelectedItem as DataRowView).Row.ItemArray[0];


            var dialogResult = Upraveny_MessageBox.Show("Odstrániť objednávku", "Naozaj chceš odstrániť objednávku a všetky jej tovary? Číslo objednávky: " + objednavkaID + " ?", MessageBoxButton.YesNo, Bakalarka.Windows.MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("delete from objednavka where objednavkaID = " + "'" + objednavkaID + "'", mainWindow.Databaza.Connection);
                    cmd.ExecuteNonQuery();
                    Upraveny_MessageBox.Show("Objednávka bola úspešne odstránená");
                    mainWindow.Databaza.zobrazObjednavky(this);
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
            foreach(TovaryNaZobrazenie tovaryNaZobrazenie in tovaryNaZobrazenieList)
            {
                tovaryNaZobrazenie.Close();
            }
        }
    }
}
