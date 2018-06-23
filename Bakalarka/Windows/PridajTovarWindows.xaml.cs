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



    public partial class PridajTovarWindows : Window, INotifyPropertyChanged
    {
        PridajObjednavku pridajObjednavku;
        String vybratyDodavatel;

        public event PropertyChangedEventHandler PropertyChanged;

        public String VybratyDodavatel
        {
            get => vybratyDodavatel; set
            {
                if (vybratyDodavatel != value)
                {
                    vybratyDodavatel = value;
                    OnPropertyChanged("VybratyDodavatel");
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


        public PridajTovarWindows(PridajObjednavku pPridajObjednavku)
        {
            InitializeComponent();
            DataContext = this;
            pridajObjednavku = pPridajObjednavku;
            DataContext = this;
            vybratyDodavatel = (String)(pridajObjednavku.dodavatel.SelectedItem as DataRowView).Row.ItemArray[1];
        }

        private void ButtPridajTovar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool prvaTriedaInfo = false;

                if (prvaTrieda.IsChecked == true)
                {
                    prvaTriedaInfo = true;
                }

                DataTable pom = new DataTable();

                using (OracleCommand cmd = new OracleCommand("select * from tovar where tovarID = '" + cisloBaliku.Text + "'"
             , pridajObjednavku.MainWindow.Databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {

                        pom.Load(reader);
                    }
                }


                foreach (var tovarpom in pridajObjednavku.TovaryVObjednavky)
                {
                    if (tovarpom.CisloBaliku == cisloBaliku.Text)
                    {
                        throw new Exception("Tovar s takým číslom už existuje");
                    }
                }

                if (pom.Rows.Count != 0)
                {
                    throw new Exception("Tovar s takým číslom už existuje");
                }


                Tovar tovar = new Tovar(cisloBaliku.Text, new Prijemca(menoPrijemcu.Text, mesto.Text + " " + ulica.Text + " " + cisloDomu.Text, telefon.Text),
                    Convert.ToDecimal(sirka.Text), Convert.ToDecimal(vyska.Text), Convert.ToDecimal(dlzka.Text),
                    Convert.ToDecimal(hmotnost.Text), prvaTriedaInfo, vybratyDodavatel);

                pridajObjednavku.TovaryVObjednavky.Add(tovar);
                pridajObjednavku.tovaryVObjednavkeCombo.Items.Refresh();

                Upraveny_MessageBox.Show("Úspešne si pridal tovar");
            }

            catch (FormatException)
            {
                Upraveny_MessageBox.Show("Zadal si zlý formát čísla (desatinné čisla sa píšu s ',')");
            }

            catch (Exception ex)
            {
                Upraveny_MessageBox.Show(ex.ToString());
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
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
