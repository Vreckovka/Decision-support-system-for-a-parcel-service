using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Bakalarka.Mapa
{
    public class Cesta : INotifyPropertyChanged
    {
        List<String> _destinacie;
        String _nazovCesty;
        public Cesta(List<String> destinacie, String nazovCesty)
        {
            _destinacie = destinacie;
            _nazovCesty = nazovCesty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string NazovCesty
        {
            get => _nazovCesty; set
            {
                if (_nazovCesty != value)
                {
                    _nazovCesty = value;
                    OnPropertyChanged("NazovCesty");
                }
            }
        }

        public List<String> Destinacie
        {
            get => _destinacie; set
            {
                if (_destinacie != value)
                {
                    _destinacie = value;
                    OnPropertyChanged("Destinacie");
                }
            }
        }
    }
}
