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
using Bakalarka.Pages;

namespace Bakalarka.Windows
{
    /// <summary>
    /// Interaction logic for PridajVozidloWindow.xaml
    /// </summary>
    public partial class PridajVozidloWindow : Window
    {
        MainWindow hlavneOkno;
        ZobrazVozidlaPage zobrazVozidlaPage;
        string isMaxed = "[ ]";
       

        public PridajVozidloWindow(MainWindow mainWindow, ZobrazVozidlaPage pZobrazVozidlaPage)
        {
            InitializeComponent();
            DataContext = this;
            hlavneOkno = mainWindow;
            zobrazVozidlaPage = pZobrazVozidlaPage;
        }

        public string IsMaxed { get => isMaxed; set => isMaxed = value; }

        private void ButtPridajVozidlo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hlavneOkno.Databaza.pridajVozidlo(spz.Text, znacka.Text, typ.Text, Convert.ToDouble(vyskaKuf.Text), Convert.ToDouble(sirkaKuf.Text), Convert.ToDouble(dlzkaKuf.Text),
                    Convert.ToDouble(nosnosť.Text), Convert.ToDouble(najazdeneKM.Text), Convert.ToDateTime(datumEvidencie.Text), Convert.ToDateTime(datumStk.Text), Convert.ToDateTime(datumEmisnej.Text));
            }
            catch (System.FormatException)
            {
                Upraveny_MessageBox.Show("Zlý formát");
            }

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
