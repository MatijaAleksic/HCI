using System;
using System.ComponentModel;

using Newtonsoft.Json;

namespace HCI_T5._4.modeli
{
    public class Gost
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _ime;

        public string Ime
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

        [JsonConstructor]
        public Gost(String _ime)
        {
            this._ime = _ime;
        }
    }
}
