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
    /// Interaction logic for PridajDodavatela.xaml
    /// </summary>
    public partial class PridajDodavatelaWindow : Window
    {
        MainWindow mainWindow;
        ZobrazDodavatelov zobrazDodavatelov;
        string isMaxed = "[ ]";
       

        public PridajDodavatelaWindow(MainWindow pmainWindow, ZobrazDodavatelov pZobrazDodavatelov)
        {
            InitializeComponent();
            DataContext = this;
            mainWindow = pmainWindow;
            zobrazDodavatelov = pZobrazDodavatelov;
            
        }

        public string IsMaxed { get => isMaxed; set => isMaxed = value; }

        private void ButtPridajDodavatela_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.Databaza.pridajDodavatela(mesto.Text + " " + ulica.Text + " " + cisloDomu.Text, ico.Text, meno.Text);
            } catch (System.FormatException)
            {
                MessageBox.Show("Zadal si zlý formát čísla");
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
