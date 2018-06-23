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
using Bakalarka.Pages;
using Bakalarka.Triedy;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;
using Bakalarka.Triedy.Databaza;
using Oracle.ManagedDataAccess.Client;

namespace Bakalarka.Windows
{
    /// <summary>
    /// Interaction logic for PridajObjednavku.xaml
    /// </summary>
    public partial class PridajObjednavku : Window, INotifyPropertyChanged
    {
        MainWindow mainWindow;
        List<Tovar> tovaryVObjednavky;
        PridajTovarWindows pridajTovarWindows;
        DataTable zoznamDodavatelov;

        public List<Tovar> TovaryVObjednavky
        {
            get => tovaryVObjednavky; set
            {
                if (tovaryVObjednavky != value)
                {
                    tovaryVObjednavky = value;
                    OnPropertyChanged("TovaryVObjednavky");
                }
            }
        }

        public DataTable ZoznamDodavatelov
        {
            get => zoznamDodavatelov; set
            {
                if (zoznamDodavatelov != value)
                {
                    zoznamDodavatelov = value;
                    OnPropertyChanged("ZoznamDodavatelov");
                }
            }
        }
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

        public MainWindow MainWindow { get => mainWindow; set => mainWindow = value; }

        public PridajObjednavku(MainWindow pMainWindow)
        {
            InitializeComponent();
            DataContext = this;
            MainWindow = pMainWindow;
            zoznamDodavatelov = MainWindow.Databaza.dajVsetkychDodavatelov();

            tovaryVObjednavky = new List<Tovar>();
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

        private void ButtPridajObjednavku_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cisloObjednavky.Text.Length != 10)
                {
                    throw new Exception("Číslo objednávky musí mať 10 znakov");
                }

                if (TovaryVObjednavky.Count <= 0)
                {
                    throw new Exception("Nie je pridaný žiadny tovar, musí byť pridaný aspoň jeden");
                }




                if (MainWindow.Databaza.pridajObjednavku(cisloObjednavky.Text, Convert.ToDateTime(datumDodania.Text), (string)dodavatel.SelectedValue + "") == false)
                {
                    throw new Exception("Nepodarilo sa pridat objednávku");
                }

                foreach (Tovar tovar in TovaryVObjednavky)
                {
                    MainWindow.Databaza.pridajPrijemcu(tovar.Prijemca.Meno, tovar.Prijemca.Adresa, tovar.Prijemca.Telefon);


                    var prvaTrieda = Oracle.ManagedDataAccess.Types.OracleDecimal.Zero;
                    if (tovar.PrvaTrieda == true)
                    {
                        prvaTrieda = Oracle.ManagedDataAccess.Types.OracleDecimal.One;
                    }
                    DataTable dataTable;
                    using (OracleCommand cmd = new OracleCommand("select prijemcaID from prijemca where meno = " + "'" + tovar.Prijemca.Meno + "'" +
                        " and adresa = " + "'" + tovar.Prijemca.Adresa + "'" + " and telefon = " + "'" + tovar.Prijemca.Telefon + "'"
                        , MainWindow.Databaza.Connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                           dataTable = new DataTable();
                            dataTable.Load(reader);
                         
                        }
                    }

                    MainWindow.Databaza.pridajTovar(tovar.CisloBaliku, (double)tovar.Hmotnost, (double)tovar.Sirka, (double)tovar.Vyska, (double)tovar.Dlzka,
                                Convert.ToInt16(dataTable.Rows[0].ItemArray[0]), cisloObjednavky.Text, prvaTrieda);
                }

                MainWindow.nacitajDnesPrichadzajuceObjednavky();

                Upraveny_MessageBox.Show("Úspešne si pridal objednávku");

            }
            catch (Exception ex)
            {
                Upraveny_MessageBox.Show(ex.ToString());
            }
            
        }

        private void ButtPridajTovar_Click(object sender, RoutedEventArgs e)
        {
            if (dodavatel.SelectedItem == null)
            {
                Upraveny_MessageBox.Show("Nie je vybratý žiadny dodávateľ");
            }
            else
            {
                pridajTovarWindows = new PridajTovarWindows(this);
                pridajTovarWindows.Visibility = Visibility.Visible;
            }
        }

        private void dodavatel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String IcoDodavatela = (String)(dodavatel.SelectedItem as DataRowView).Row.ItemArray[1];
            foreach (Tovar tovar in tovaryVObjednavky)
            {
                tovar.DodavatelIco = IcoDodavatela;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (pridajTovarWindows != null)
                pridajTovarWindows.Close();
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
