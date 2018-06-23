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

using System.ComponentModel;

namespace Bakalarka.Windows
{
    /// <summary>
    /// Interaction logic for CestaNaZobrazenie.xaml
    /// </summary>
    public partial class CestaNaZobrazenie : Window, INotifyPropertyChanged
    {
        List<String> zoznamAdries;
        String nazovCesty;
        string isMaxed = "[ ]";
        public CestaNaZobrazenie()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public List<String> ZoznamAdries
        {
            get => zoznamAdries; set
            {
                if (zoznamAdries != value)
                {
                    zoznamAdries = value;
                    OnPropertyChanged("ZoznamAdries");
                }
            }
        }

        public String NazovCesty
        {
            get => nazovCesty; set
            {
                if (nazovCesty != value)
                {
                    nazovCesty = value;
                    OnPropertyChanged("NazovCesty");
                }
            }
        }

        public string IsMaxed { get => isMaxed; set => isMaxed = value; }

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
