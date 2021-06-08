using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.ComponentModel;

using Newtonsoft.Json;

namespace HCI_T5._4.modeli
{
	public class Associate : INotifyPropertyChanged
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
		private EnterpriseType _type;
		private string _adresa;
		private string _grad;
		private List<Product> _proizvodi;

		[NonSerialized]
		private WriteableBitmap _slicica;


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

		public string Adresa
		{
			get
			{
				return _adresa;
			}
			set
			{
				if (value != _adresa)
				{
					_adresa = value;
					OnPropertyChanged("Adresa");
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

		public EnterpriseType Type
		{
			get
			{
				return _type;
			}
			set
			{
				if (value != _type)
				{
					_type = value;
					OnPropertyChanged("Type");
				}
			}
		}

		public WriteableBitmap Slicica
		{
			get
			{
				return _slicica;
			}
			set
			{
				if (value != _slicica)
				{
					_slicica = value;
					OnPropertyChanged("Slicica");
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

		public Associate(string _ime,EnterpriseType _type, string _adresa, string _grad,List<Product> _proizvodi, WriteableBitmap _slicica)
		{
			this._ime = _ime;
			this._type = _type;
			this._adresa = _adresa;
			this._grad = _grad;
			this._proizvodi = _proizvodi;
			this._slicica = _slicica;
		}

		[JsonConstructor]
		public Associate(string _ime, EnterpriseType _type, string _adresa, string _grad, List<Product> _proizvodi)
		{
			this._ime = _ime;
			this._type = _type;
			this._adresa = _adresa;
			this._grad = _grad;
			this._proizvodi = _proizvodi;
		}



	}
}

