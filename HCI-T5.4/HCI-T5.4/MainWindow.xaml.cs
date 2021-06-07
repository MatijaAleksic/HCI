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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Drawing;

using System.Collections.ObjectModel;

using Newtonsoft.Json;
using System.IO;

using HCI_T5._4.modeli;


namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Admin> Administratori { get; set; }
        public ObservableCollection<Organiser> Organizatori { get; set; }
        public ObservableCollection<Client> Klijenti { get; set; }

        readonly public string pathAdministratora = @"..\..\..\data\administratori.txt";
        readonly public string pathOrganizatora = @"..\..\..\data\organizatori.txt";
        readonly public string pathKlijenata = @"..\..\..\data\klijenti.txt";


        public MainWindow()
        {
            this.Hide();

            Util util = new Util();

            Administratori = util.read_file<Admin>(pathAdministratora);
            Organizatori = util.read_file<Organiser>(pathOrganizatora);
            Klijenti = util.read_file<Client>(pathKlijenata);

            var adminHome = new HCI_T5._4.AdminMainWindow(this);
            adminHome.Show();

            //var login = new HCI_T5._4.Login(this);
            //login.Show();
        }





        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var login = new HCI_T5._4.Login(this);
            //login.DataContext = this;
            //login.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var login = new HCI_T5._4.Login(this);
            login.Show();
        }
    }
}
