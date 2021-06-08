using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

using Newtonsoft.Json;

namespace HCI_T5._4.modeli
{
    [Serializable]
    public class Product : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        //private Associate _saradnik;
        private String _ime;
        private int _cena;

        [NonSerialized]
        private WriteableBitmap _slicica;



        /*public Associate Saradnik
        {
            get
            {
                return _saradnik;
            }
            set
            {
                _saradnik = value;
                OnPropertyChanged("Saradnik");
            }
        }*/

        public String Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                _ime = value;
                OnPropertyChanged("Ime");
            }
        }
        public int Cena
        {
            get
            {
                return _cena;
            }
            set
            {
                _cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public Product(String _ime, int _cena, WriteableBitmap _slicica) //( Associate _saradnik, String _ime, int _cena, WriteableBitmap _slicica)
        {
            this._ime = _ime;
            this._cena = _cena;
            this._slicica = _slicica;
        }

        [JsonConstructor]
        public Product(String _ime, int _cena) 
        {
            this._ime = _ime;
            this._cena = _cena;
        }


    }
}
