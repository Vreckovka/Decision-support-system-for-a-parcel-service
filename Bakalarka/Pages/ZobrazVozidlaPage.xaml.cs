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
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Bakalarka.Windows;

namespace Bakalarka.Pages
{
    /// <summary>
    /// Interaction logic for VsetkyVozidlaPage.xaml
    /// </summary>
    public partial class ZobrazVozidlaPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<Vozidlo> vozidlaNaZobrazenie;
        MainWindow mainWindow;
        List<TovaryNaZobrazenie> tovaryNaZobrazenieList;
        public List<Vozidlo> VozidlaNaZobrazenie
        {
            get => vozidlaNaZobrazenie; set
            {
                if (vozidlaNaZobrazenie != value)
                {
                    vozidlaNaZobrazenie = value;
                    OnPropertyChanged("VozidlaNaZobrazenie");
                }
            }
        }

        public ZobrazVozidlaPage(MainWindow pmainWindow)
        {
            InitializeComponent();
            tovaryNaZobrazenieList = new List<TovaryNaZobrazenie>();
            mainWindow = pmainWindow;
            DataContext = this;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var vozidloSPZ = (vsetkyVozidlaGrid.SelectedItem as DataRowView).Row.ItemArray[12];            
            var dialogResult = Upraveny_MessageBox.Show("Odstrániť vozidlo", "Naozaj chceš odstrániť vozidlo s SPZ: " + vozidloSPZ + " ?", MessageBoxButton.YesNo, Bakalarka.Windows.MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("delete from vozidlo where vozidloID = " + "'" + vozidloSPZ + "'", mainWindow.Databaza.Connection);
                    cmd.ExecuteNonQuery();
                    Upraveny_MessageBox.Show("Vozidlo bolo úspešne odstránené");
                    mainWindow.Databaza.zobrazVozidla(this);
                }
                catch (Exception ex)
                {
                    Upraveny_MessageBox.Show(ex.Message);
                }
            }

           
        }

        private void Objednavka_Click(object sender, MouseButtonEventArgs e)
        {

            var vozidlo = ((sender as DataGridCell).DataContext as DataRowView);
            var vozidloID = vozidlo.Row.ItemArray[12];

            TovaryNaZobrazenie tovaryVoVozidle = new TovaryNaZobrazenie(mainWindow, (string)vozidloID);
            tovaryVoVozidle.NeZobrazit = true;
            tovaryNaZobrazenieList.Add(tovaryVoVozidle);

            try
            {
                using (OracleCommand cmd = new OracleCommand("select tovarID,datumDorucenia,DatumPrijatiaNaSklad," +
                    "Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) " +
                    "where vozidloID = " + "'" + vozidloID + "'"
                    , mainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        tovaryVoVozidle.vsetkyTovaryGrid.DataContext = dataTable; ;
                        tovaryVoVozidle.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
