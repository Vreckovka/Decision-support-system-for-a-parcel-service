using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bakalarka.Triedy
{
   public class Prijemca : INotifyPropertyChanged
    {
        int id;
        String meno;
        String adresa;
        List<Tovar> dorucenyTovar;
        String telefon;

        public Prijemca(String pMeno, String pAdresa, String pTelefon)
        {
            meno = pMeno;
            Adresa = pAdresa;
            telefon = pTelefon;
            DorucenyTovar = new List<Tovar>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public String Meno
        {
            get => meno; set
            {
                if (meno != value)
                {
                    meno = value;
                    OnPropertyChanged("Meno");
                }
            }
        }

        public String Telefon
        {
            get => telefon; set
            {
                if (telefon != value)
                {
                    telefon = value;
                    OnPropertyChanged("Telefon");
                }
            }
        }

        public String Adresa
        {
            get => adresa; set
            {
                if (adresa != value)
                {
                    adresa = value;
                    OnPropertyChanged("Adresa");
                }
            }
        }

        public int Id { get => id; set => id = value; }
        public List<Tovar> DorucenyTovar { get => dorucenyTovar; set => dorucenyTovar = value; }
    }

   
}
