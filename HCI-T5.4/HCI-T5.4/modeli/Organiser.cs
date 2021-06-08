using System.ComponentModel;
using Newtonsoft.Json;

namespace HCI_T5._4.modeli
{
    public class Organiser : INotifyPropertyChanged
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
		private string _prezime;
		private string _email;

		private string _username;
		private string _password;


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

		public string Prezime
		{
			get
			{
				return _prezime;
			}
			set
			{
				if (value != _prezime)
				{
					_prezime = value;
					OnPropertyChanged("Prezime");
				}
			}
		}

		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				if (value != _email)
				{
					_email = value;
					OnPropertyChanged("Email");
				}
			}
		}

		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				if (value != _username)
				{
					_username = value;
					OnPropertyChanged("Username");
				}
			}
		}

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				if (value != _password)
				{
					_password = value;
					OnPropertyChanged("Password");
				}
			}
		}


		[JsonConstructor]
		public Organiser(string ime, string prezime, string email, string username, string password)
		{
			_ime = ime;
			_prezime = prezime;
			_email = email;
			_username = username;
			_password = password;
		}

	}
}
