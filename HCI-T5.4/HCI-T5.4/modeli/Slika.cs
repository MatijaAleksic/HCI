using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

using Newtonsoft.Json;

namespace HCI_T5._4.modeli
{
    public class Slika : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private WriteableBitmap _slicica;

        public WriteableBitmap Slicica
        {
            get
            {
                return _slicica;
            }
            set
            {
                _slicica = value;
                OnPropertyChanged("Slicica");
            }
        }

        [JsonConstructor]
        public Slika(WriteableBitmap _slicica)
        {
            this._slicica = _slicica;
        }
    }
}

