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
using Bakalarka.Windows;
using Oracle.ManagedDataAccess.Client;

namespace Bakalarka.Pages
{
    /// <summary>
    /// Interaction logic for ZobrazTovaryPage.xaml
    /// </summary>
    public partial class ZobrazTovaryPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<Tovar> tovaryNaZobrazenie;

        public List<Tovar> TovaryNaZobrazenie
        {
            get => tovaryNaZobrazenie; set
            {
                if (tovaryNaZobrazenie != value)
                {
                    tovaryNaZobrazenie = value;
                    OnPropertyChanged("TovaryNaZobrazenie");
                }
            }
        }

        double vyska;
        double sirka;

        MainWindow mainWindow;
        public double Sirka
        {
            get => sirka; set
            {
                if (sirka != value)
                {
                    sirka = value;
                    OnPropertyChanged("Sirka");
                }
            }
        }

        public double Vyska
        {
            get => vyska; set
            {
                if (vyska != value)
                {
                    vyska = value;
                    OnPropertyChanged("Vyska");
                }
            }
        }
        public ZobrazTovaryPage(MainWindow pmainWindow)
        {
            InitializeComponent();
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

            var tovarID = (vsetkyTovaryGrid.SelectedItem as DataRowView).Row.ItemArray[1];
            var dialogResult = Upraveny_MessageBox.Show("Odstrániť tovar", "Naozaj chceš odstrániť tovar : " + tovarID + " ?", MessageBoxButton.YesNo, Bakalarka.Windows.MessageBoxImage.Warning);

            if (dialogResult == MessageBoxResult.Yes)
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("delete from tovar where tovarID = " + "'" + tovarID + "'", mainWindow.Databaza.Connection);
                    cmd.ExecuteNonQuery();
                    Upraveny_MessageBox.Show("Tovar bol úspešne odstránený");
                    mainWindow.Databaza.zobrazTovary(this);
                }
                catch (Exception ex)
                {
                    Upraveny_MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
