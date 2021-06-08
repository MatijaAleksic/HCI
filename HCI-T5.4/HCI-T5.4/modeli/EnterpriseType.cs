	using System.ComponentModel;

namespace HCI_T5._4.modeli
{
    public class EnterpriseType : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string name)
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
				if (value != _ime)
				{
					_ime = value;
					OnPropertyChanged("Ime");
				}
			}
		}

		public EnterpriseType(string _ime)
		{
			this._ime = _ime;
		}
	}
}
