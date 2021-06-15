using HCI_T5._4.modeli;
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

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for RegistracijaAdmin.xaml
    /// </summary>
    public partial class RegistracijaAdmin : Window
    {
        private MainWindow MainWindow { get; set; }
        string pathAdmina = @"..\..\..\data\administratori.txt";

        public RegistracijaAdmin()
        {
            InitializeComponent();
        }

        public RegistracijaAdmin(MainWindow window)
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
                if (admin.Username.Equals(Username.Text) || admin.Email.Equals(Email.Text))
                {
                    uspesno = false;
                    MessageBox.Show("Administrator sa ovim kredencijalima vec postoji!");
                    break;
                }
            }
            if (uspesno)
            {
                Admin newAdmin = new Admin(Firstname.Text, Lastname.Text, Email.Text, Username.Text, Password.Password);

                this.MainWindow.Administratori.Add(newAdmin);

                util.write_to_file<Admin>(this.MainWindow.Administratori, pathAdmina);

                MessageBox.Show("Uspjesna registracija!");
                this.Close();
            }
        }
        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "DodavanjeAdministratora";
            HelpProvider.ShowHelp(str);
        }
    }
}
