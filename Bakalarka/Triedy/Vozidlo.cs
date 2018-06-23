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
using Newtonsoft.Json;
using GMap.NET;

namespace Bakalarka.Triedy
{

   public class Vozidlo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        decimal dlzkaKufru;
        decimal sirkaKufru;
        decimal vyskaKufru;
        decimal nosnost;
        bool pouzite;
        decimal objemVozidla;

        PointLatLng polohaVozidla;
        String spz;

        List<String> trasa;

        bool aktivne;

        decimal naplnenyObjem;
        decimal naplnenaNosnost;
        public Vozidlo(String pSpz, decimal pSirkaKufru, decimal pDlzkaKufru, decimal pVyskaKufru, decimal pnosnost)
        {
            spz = pSpz;
            sirkaKufru = pSirkaKufru;
            dlzkaKufru = pDlzkaKufru;
            vyskaKufru = pVyskaKufru;
            nosnost = pnosnost;
            //TovarVoVozidle = new List<Tovar>();
            aktivne = false;

        }

        public Vozidlo(decimal pnosnost, decimal pObjemVozidla, String pSpz)
        {
            nosnost = pnosnost;
            objemVozidla = pObjemVozidla;
            TovarVoVozidle = new List<String>();
            aktivne = false;
            NaplnenyObjem = 0;
            spz = pSpz;
        }

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
        //public bool pridajTovarDoVozidla(Tovar tovar)
        //{
        //    decimal objemVozidla = dlzkaKufru * sirkaKufru * vyskaKufru;
        //    if (NaplnenyObjem + (tovar.Vyska * tovar.Sirka * tovar.Dlzka) <= objemVozidla && 
        //        tovar.Vyska <= vyskaKufru && tovar.Sirka <= sirkaKufru && tovar.Dlzka <= dlzkaKufru 
        //        && naplnenaNosnost + tovar.Hmotnost <= nosnost)
        //    {
        //        TovarVoVozidle.Add(tovar);
        //        NaplnenyObjem += (tovar.Vyska * tovar.Sirka * tovar.Dlzka);
        //        naplnenaNosnost += tovar.Hmotnost;
        //        return true;
        //    }
        //    return false;
        //}
        public string SPZ
        {
            get => spz; set
            {
                if (spz != value)
                {
                    spz = value;
                    OnPropertyChanged("SPZ");
                }
            }
        }

        public PointLatLng PolohaVozidla
        {
            get => polohaVozidla; set
            {
                if (polohaVozidla != value)
                {
                    polohaVozidla = value;
                    OnPropertyChanged("PolohaVozidla");
                }
            }
        }
   
        public decimal DlzkaKufru
        {
            get => dlzkaKufru; set
            {
                if (dlzkaKufru != value)
                {
                    dlzkaKufru = value;
                    OnPropertyChanged("DlzkaKufru");
                }
            }
        }

        public decimal SirkaKufru
        {
            get => sirkaKufru; set
            {
                if (sirkaKufru != value)
                {
                    sirkaKufru = value;
                    OnPropertyChanged("SirkaKufru");
                }
            }
        }

        public decimal VyskaKufru
        {
            get => vyskaKufru; set
            {
                if (vyskaKufru != value)
                {
                    vyskaKufru = value;
                    OnPropertyChanged("VyskaKufru");
                }
            }
        }

   

        public bool Aktivne
        {
            get => aktivne; set
            {
                if (aktivne != value)
                {
                    aktivne = value;
                    OnPropertyChanged("Aktivne");
                }
            }
        }

        public List<String> TovarVoVozidle { get => trasa; set => trasa = value; }
        public decimal ObjemVozidla { get => objemVozidla; set => objemVozidla = value; }
        public bool Pouzite { get => pouzite; set => pouzite = value; }
        public decimal NaplnenyObjem { get => naplnenyObjem; set => naplnenyObjem = value; }
    }
}
