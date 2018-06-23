using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bakalarka.Triedy;
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
    public class Dodavatel : INotifyPropertyChanged
    {
        String ico;
        String meno;
        int index;

        public Dodavatel(String pMeno, String pIco,  int pIndex)
        {
            meno = pMeno;
            ico = pIco;
            Index = pIndex;
        }

        public Dodavatel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
 
        public String Ico
        {
            get => ico; set
            {
                if (ico != value)
                {
                    ico = value;
                    OnPropertyChanged("Ico");
                }
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

        public int Index { get => index; set => index = value; }
    }
}
