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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private MainWindow MainWindow { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        public Login(MainWindow window)
        {
            InitializeComponent();
            this.MainWindow = window;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Boolean uspesno = false;

            foreach (Admin admin in this.MainWindow.Administratori)
            {
                if (admin.Username.Equals(Username.Text) && admin.Password.Equals(Password.Password))
                {
                    MessageBox.Show("Uspjesan login");
                    Application.Current.MainWindow = MainWindow;
                    this.Close();
                    this.MainWindow.Show();
                    uspesno = true;
                    break;
                }
            }
            if (!uspesno)
            {
                MessageBox.Show("Neipravni kredencijali, pokusajte ponovo");
            }
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            var register = new Register(this.MainWindow);
            register.Show();
        }
    }
}
