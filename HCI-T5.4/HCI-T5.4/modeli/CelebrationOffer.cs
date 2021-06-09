using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HCI_T5._4.modeli
{
	public enum CelebrationOfferStatus
	{
		Ponudjen,
		Prihvacen,
		Odbijen
	}

	public class CelebrationOffer : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		private int _zahtev_idx;
		private Associate _saradnik;
		private CelebrationOfferStatus _status;
		private List<Product> _proizvodi;


		public int ZahtevIdx
		{
			get
			{
				return _zahtev_idx;
			}
			set
			{
				if (value != _zahtev_idx)
				{
					_zahtev_idx = value;
					OnPropertyChanged("ZahtevIdx");
				}
			}
		}

		public Associate Saradnik
		{
			get
			{
				return _saradnik;
			}
			set
			{
				if (value != _saradnik)
				{
					_saradnik = value;
					OnPropertyChanged("Saradnik");
				}
			}
		}

		public CelebrationOfferStatus Status
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

		public List<Product> Proizvodi
		{
			get
			{
				return _proizvodi;
			}
			set
			{
				if (value != _proizvodi)
				{
					_proizvodi = value;
					OnPropertyChanged("Proizvodi");
				}
			}
		}

		public CelebrationOffer(int _zahtev_idx, Associate _saradnik,	CelebrationOfferStatus _status,
			List<Product> _proizvodi)
		{
			this._zahtev_idx = _zahtev_idx;
			this._saradnik = _saradnik;
			this._status = _status;
			this._proizvodi = _proizvodi;
		}
	}
}
