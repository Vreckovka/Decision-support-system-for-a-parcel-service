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

using System.Threading;

namespace Bakalarka.Mapa.Pages
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : Page
    {
        public  bool restart;
        public LoadingPage()
        {
            InitializeComponent();

            restart = false;
        }

        public void updateProgressBar(double percetage)
        {           
            this.Dispatcher.Invoke(() =>
            {
                ProgressBar.Value += percetage;
                percentaText.Text = String.Format("{0:0.##} %", ProgressBar.Value); ;
            });
         
        }

        public void zmenStatus(String statusText)
        {
            this.Dispatcher.Invoke(() =>
            {
                TextStatus.Text = statusText;
            });

        }

        public void zmenStatusPodrob(String statusText)
        {
            this.Dispatcher.Invoke(() =>
            {
                TextStatusPodrob.Text = statusText;
            });

        }
    }
}
