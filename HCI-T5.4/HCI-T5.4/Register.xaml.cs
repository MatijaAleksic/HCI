using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using HCI_T5._4.modeli;

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    

    public partial class Register : Window
    {
        private MainWindow MainWindow { get; set; }
        string pathKlijenata = @"..\..\..\data\klijenti.txt";

        public Register()
        {
            InitializeComponent();
        }

        public Register(MainWindow window)
        {
            InitializeComponent();
            this.MainWindow = window;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Boolean uspesno = true;
            Util util = new Util();

            foreach (Admin admin in this.MainWindow.Administratori)
            {
                if (admin.Username.Equals(Username.Text) && admin.Password.Equals(Password.Password))
                {
                    uspesno = false;
                    MessageBox.Show("Korisnik sa ovim kredencijalima vec postoji!");
                    break;
                }
            }
            if (uspesno)
            {
                Client newClient = new Client(Firstname.Text, Lastname.Text, Email.Text, Username.Text, Password.Password);

                this.MainWindow.Klijenti.Add(newClient);

                util.write_to_file<Client>(this.MainWindow.Klijenti, pathKlijenata);

                MessageBox.Show("Uspjesna registracija!");
                this.Close();
            }
        }
    }
}
