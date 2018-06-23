using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
    public class Objednavka : INotifyPropertyChanged
    {
        String cisloDodaciehoListu;
        DateTime datumDodania;
        String dodavatel;
        List<Tovar> tovary;

        public Objednavka(String pCisloDodaciehoListu, DateTime pDatumDodania, String pDodavatel,List<Tovar> pTovary)
        {
            CisloDodaciehoListu = pCisloDodaciehoListu;
            DatumDodania = pDatumDodania;
            Dodavatel = pDodavatel;
            tovary = pTovary;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public String vytvorJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public String CisloDodaciehoListu
        {
            get => cisloDodaciehoListu; set
            {
                if (cisloDodaciehoListu != value)
                {
                    cisloDodaciehoListu = value;
                    OnPropertyChanged("CisloDodaciehoListu");
                }
            }
        }

        public DateTime DatumDodania
        {
            get => datumDodania; set
            {
                if (datumDodania != value)
                {
                    datumDodania = value;
                    OnPropertyChanged("DatumDodania");
                }
            }
        }

        public List<Tovar> Tovary
        {
            get => tovary; set
            {
                if (tovary != value)
                {
                    tovary = value;
                    OnPropertyChanged("Tovary");
                }
            }
        }

        public String Dodavatel
        {
            get => dodavatel; set
            {
                if (dodavatel != value)
                {
                    dodavatel = value;
                    OnPropertyChanged("Dodavatel");
                }
            }
        }
    }
}
