using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

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

        public string Id { get; set; }
        private String _ime;
        private int _cena;

        [NonSerialized]
        private WriteableBitmap _slicica;



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


    }
}
