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

        public ObservableCollection<EnterpriseType> TipoviPreduzeca { get; set; }
        public ObservableCollection<CelebrationRequest> Zahtevi { get; set; }
        public ObservableCollection<Associate> Saradnici { get; set; }
        public ObservableCollection<CelebrationOffer> Ponude { get; set; }

        readonly public string pathAdministratora = @"..\..\..\data\administratori.txt";
        readonly public string pathOrganizatora = @"..\..\..\data\organizatori.txt";
        readonly public string pathKlijenata = @"..\..\..\data\klijenti.txt";
        readonly public string pathTipPreduzeca = @"..\..\..\data\tippreduzeca.txt";
        readonly public string pathZahtevi = @"..\..\..\data\zahtevi.txt";
        readonly public string pathSaradnici = @"..\..\..\data\saradnici.txt";
        readonly public string pathPonude = @"..\..\..\data\ponude.txt";

        public String loggedUsername;
        public int zahtev_idx = 0;


        public Util util = new Util();


        public MainWindow()
        {
            this.Hide();

            Administratori = util.read_file<Admin>(pathAdministratora);
            Organizatori = util.read_file<Organiser>(pathOrganizatora);
            Klijenti = util.read_file<Client>(pathKlijenata);

            TipoviPreduzeca = util.read_file<EnterpriseType>(pathTipPreduzeca);
            Zahtevi = util.read_file<CelebrationRequest>(pathZahtevi);
            Saradnici = util.read_file<Associate>(pathSaradnici);

            Ponude = util.read_file<CelebrationOffer>(pathPonude);

            zahtev_idx = Zahtevi.Count;

            //var clientHome = new HCI_T5._4.KlientMainWindow(this);
            //clientHome.Show();

            //var adminHome = new HCI_T5._4.AdminMainWindow(this);
            //adminHome.Show();

            var login = new HCI_T5._4.Login(this);
            login.Show();
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
