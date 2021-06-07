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


        public MainWindow()
        {
            this.Hide();

            string pathAdministratora = @"..\..\..\data\administratori.txt";
            string pathOrganizatora = @"..\..\..\data\organizatori.txt";
            string pathKlijenata = @"..\..\..\data\klijenti.txt";

            Util util = new Util();

            Administratori = util.read_file<Admin>(pathAdministratora);
            Organizatori = util.read_file<Organiser>(pathOrganizatora);
            Klijenti = util.read_file<Client>(pathKlijenata);


            var login = new HCI_T5._4.Login(this);
            login.Show();
        }





        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var login = new HCI_T5._4.Login(this);
            //login.DataContext = this;
            //login.Show();
        }
    }
}
