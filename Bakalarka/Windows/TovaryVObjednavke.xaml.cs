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


namespace Bakalarka.Windows
{
    /// <summary>
    /// Interaction logic for TovaryVObjednavke.xaml
    /// </summary>
    public partial class TovaryVObjednavke : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<Tovar> tovaryNaZobrazenie;
        MainWindow mainWindow;
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

        List<Tovar> tovaryNaPrijatie;

        public TovaryVObjednavke(MainWindow pMainWindow)
        {

            InitializeComponent();
            mainWindow = pMainWindow;
            tovaryNaPrijatie = new List<Tovar>();
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

        private void PrijatCheckBox_Click(object sender, RoutedEventArgs e)
        {
            Tovar tovar = (sender as CheckBox).DataContext as Tovar;           
            tovaryNaPrijatie.Add(tovar);

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Tovar tovar = (sender as CheckBox).DataContext as Tovar;
            tovaryNaPrijatie.Remove(tovar);
        }

        private void PotvrdPrijatie_Click(object sender, RoutedEventArgs e)
        {
            List<Tovar> pomList = mainWindow.sklad.prichadzajuceTovary;

            foreach (Tovar tovar in tovaryNaPrijatie)
            {
                tovar.Prijaty = true;
                pomList.Remove(tovar);
            }
           
            mainWindow.sklad.tovarNaSklade.AddRange(tovaryNaPrijatie);
            mainWindow.sklad.vsetkyTovary.AddRange(tovaryNaPrijatie);

            mainWindow.zobrazTovaryPage.vsetkyTovaryGrid.Items.Refresh();
            vsetkyTovaryGrid.Items.Refresh();

        }
    }
}
