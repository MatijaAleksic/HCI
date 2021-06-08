using System.ComponentModel;
using System;

namespace HCI_T5._4.modeli
{
	public enum CelebrationRequestStatus
	{
		Podnesen,
		Cekanje,
		Zavrsen
	}

	public class CelebrationRequest : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		private string _vrstaProslave;
		private int _budzet;
		private DateTime _datum;
		private string _grad;
		private string _prizvodi;

		private CelebrationRequestStatus _status;
		private int _brojPonuda;

		private Client _klijent;
		private Organiser _organizator;

		public string VrstaProslave
		{
			get
			{
				return _vrstaProslave;
			}
			set
			{
				if (value != _vrstaProslave)
				{
					_vrstaProslave = value;
					OnPropertyChanged("VrstaProslave");
				}
			}
		}

		public int Budzet
		{
			get
			{
				return _budzet;
			}
			set
			{
				if (value != _budzet)
				{
					_budzet = value;
					OnPropertyChanged("Budzet");
				}
			}
		}

		public DateTime Datum
		{
			get
			{
				return _datum;
			}
			set
			{
				if (value != _datum)
				{
					_datum = value;
					OnPropertyChanged("Datum");
				}
			}
		}

		public string Grad
		{
			get
			{
				return _grad;
			}
			set
			{
				if (value != _grad)
				{
					_grad = value;
					OnPropertyChanged("Grad");
				}
			}
		}

		public string Proizvodi
		{
			get
			{
				return _prizvodi;
			}
			set
			{
				if (value != _prizvodi)
				{
					_prizvodi = value;
					OnPropertyChanged("Proizvodi");
				}
			}
		}

		public CelebrationRequestStatus Status
		{
			get
			{
				return _status;
			}
			set
			{
				if (value != _status)
				{
					_status = value;
					OnPropertyChanged("Status");
				}
			}
		}

		public int BrojPonuda
		{
			get
			{
				return _brojPonuda;
			}
			set
			{
				if (value != _brojPonuda)
				{
					_brojPonuda = value;
					OnPropertyChanged("BrojPonuda");
				}
			}
		}

		public Client Klijent
		{
			get
			{
				return _klijent;
			}
			set
			{
				if (value != _klijent)
				{
					_klijent = value;
					OnPropertyChanged("Klijent");
				}
			}
		}

		public Organiser Organizator
		{
			get
			{
				return _organizator;
			}
			set
			{
				if (value != _organizator)
				{
					_organizator = value;
					OnPropertyChanged("Organizator");
				}
			}
		}

		public CelebrationRequest(string _vrstaProslave, int _budzet, DateTime _datum, string _grad, string _prizvodi,
			CelebrationRequestStatus _status,int _brojPonuda, Client _klijent, Organiser _organizator)
		{
			this._vrstaProslave = _vrstaProslave;
			this._budzet = _budzet;
			this._datum = _datum;
			this._grad = _grad;
			this._prizvodi = _prizvodi;
			this._status = _status;
			this._brojPonuda = _brojPonuda;
			this._klijent = _klijent;
			this._organizator = _organizator;
		}

	}
}
