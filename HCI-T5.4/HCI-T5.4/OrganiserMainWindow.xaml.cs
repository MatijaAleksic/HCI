using HCI_T5._4.modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrganiserMainWindow.xaml
    /// </summary>
    public partial class OrganiserMainWindow : Window
    {
        private MainWindow MainWindow { get; set; }
        public ObservableCollection<Associate> Saradnici { get; set; }

        public ObservableCollection<CelebrationRequest> Zahtevi { get; set; }

        public ObservableCollection<String> Statusi2 { get; set; }

        public OrganiserMainWindow()
        {
            InitializeComponent();
        }

        public OrganiserMainWindow(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MainWindow = window;

            Saradnici = this.MainWindow.Saradnici;
            Statusi2 = new ObservableCollection<string>();
            Zahtevi = new ObservableCollection<CelebrationRequest>();

            foreach (CelebrationRequest cel in this.MainWindow.Zahtevi)
            {
                if (this.MainWindow.loggedUsername == cel.Organizator.Username)
                {
                    Zahtevi.Add(cel);
                }
            }

            Statusi2.Add("Podnesen");
            Statusi2.Add("Cekanje");
            Statusi2.Add("Zavrsen");
        }

        private void Saradnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new TabelaSaradnika(this.MainWindow);
            s.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new HCI_T5._4.Login(this.MainWindow);
            login.Show();
            this.Close();
        }

        private void NapraviPonudu_Click(object sender, RoutedEventArgs e)
        {
            CelebrationRequest selectedZahtev = (CelebrationRequest)dgrMain.SelectedItem;
            if (selectedZahtev != null)
            {
                var napraviPonudu = new HCI_T5._4.NapraviPonudu(this.MainWindow, selectedZahtev);
                napraviPonudu.Show();
            }
        }
            

        private void SearchZahtev_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var searched = Saradnici.Where(elem => elem.Ime.ToLower().StartsWith(SearchZahtev.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

        private void Tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String st = (String)Status.SelectedItem;
            var searched = Zahtevi.Where(elem => elem.Status.ToString().Equals(st));
            dgrMain.ItemsSource = searched;
        }
    }
}
