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
using GMap.NET;
using Bakalarka.Mapa;
using Oracle.ManagedDataAccess.Client;

namespace Bakalarka.Triedy
{
    public class Tovar : INotifyPropertyChanged
    {
        String cisloBaliku;

        decimal hmotnost;
        Prijemca prijemca;
        bool prvaTrieda;
        decimal dlzka;
        decimal sirka;
        decimal vyska;
        Vozidlo vozidlo;
        String dodavatelIco;
        public event PropertyChangedEventHandler PropertyChanged;
        String adresa;
        string tovarID;
        int hmotnostPreBatoh;
        int cenaPreBatoh;
        public Tovar(String pCisloBaliku, Prijemca pprijemca, decimal pSirka, decimal pVyska, decimal pDlzka, decimal pHmotnost, bool pprvaTrieda, String pdodavatelIco)
        {
            cisloBaliku = pCisloBaliku;
            prijemca = pprijemca;
            sirka = pSirka;
            vyska = pVyska;
            dlzka = pDlzka;
            hmotnost = pHmotnost;
            prvaTrieda = pprvaTrieda;
            DodavatelIco = pdodavatelIco;
        }

        public Tovar(String pCisloBaliku, String padresa, decimal pSirka, decimal pVyska, decimal pDlzka, decimal pHmotnost, int priorita)
        {
            cisloBaliku = pCisloBaliku;
            Adresa = padresa;
            sirka = pSirka;
            vyska = pVyska;
            dlzka = pDlzka;
            hmotnost = pHmotnost;
            hmotnostPreBatoh =  Convert.ToInt32(Math.Ceiling(sirka * vyska * Dlzka));
            cenaPreBatoh = priorita;
        }



        public Tovar(Tovar tovar)
        {
            Adresa = tovar.Adresa;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public String CisloBaliku
        {
            get => cisloBaliku; set
            {
                if (cisloBaliku != value)
                {
                    cisloBaliku = value;
                    OnPropertyChanged("CisloBaliku");
                }
            }
        }

        public Prijemca Prijemca
        {
            get => prijemca; set
            {
                if (prijemca != value)
                {
                    prijemca = value;
                    OnPropertyChanged("Prijemca");
                }
            }
        }

        public decimal Sirka
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

        public decimal Vyska
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

        public decimal Dlzka
        {
            get => dlzka; set
            {
                if (dlzka != value)
                {
                    dlzka = value;
                    OnPropertyChanged("Dlzka");
                }
            }
        }

        public decimal Hmotnost
        {
            get => hmotnost; set
            {
                if (hmotnost != value)
                {
                    hmotnost = value;
                    OnPropertyChanged("Hmotnost");
                }
            }
        }

        public bool PrvaTrieda
        {
            get => prvaTrieda; set
            {
                if (prvaTrieda != value)
                {
                    prvaTrieda = value;
                    OnPropertyChanged("PrvaTrieda");
                }
            }
        }
        public Vozidlo Vozidlo { get => vozidlo; set => vozidlo = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string TovarID { get => tovarID; set => tovarID = value; }
        public int HmotnostPreBatoh { get => hmotnostPreBatoh; set => hmotnostPreBatoh = value; }
        public int CenaPreBatoh { get => cenaPreBatoh; set => cenaPreBatoh = value; }
        public string DodavatelIco { get => dodavatelIco; set => dodavatelIco = value; }
    }
}
