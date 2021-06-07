using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private String _opis;
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
        public String Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                _opis = value;
                OnPropertyChanged("Opis");
            }
        }


    }
}
