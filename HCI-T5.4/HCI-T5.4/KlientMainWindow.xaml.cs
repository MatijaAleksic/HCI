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
using System.Collections.ObjectModel;
using HCI_T5._4.modeli;

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for KlientMainWindow.xaml
    /// </summary>
    public partial class KlientMainWindow : Window
    {
        private MainWindow MainWindow { get; set; }

        public ObservableCollection<CelebrationRequest> Zahtevi { get; set; }

        public ObservableCollection<String> Statusi2 { get; set; }

        public KlientMainWindow()
        {
            InitializeComponent();

        }

        public KlientMainWindow(MainWindow window)
        {
            InitializeComponent();

            this.DataContext = this;
            this.MainWindow = window;

            Statusi2 = new ObservableCollection<string>();

            Zahtevi = new ObservableCollection<CelebrationRequest>();

            foreach (CelebrationRequest cel in this.MainWindow.Zahtevi)
            {
                if (this.MainWindow.loggedUsername == cel.Klijent.Username)
                {
                    Zahtevi.Add(cel);
                }
            }

            Statusi2.Add("Podnesen");
            Statusi2.Add("Cekanje");
            Statusi2.Add("Zavrsen");
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new HCI_T5._4.Login(this.MainWindow);
            login.Show();
            this.Close();
        }

        private void NapraviZahtev_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            var zahtev = new HCI_T5._4.DodajNoviZahtev(this.MainWindow);
            zahtev.Show();
        }

        private void PregledajPonude_Click(object sender, RoutedEventArgs e)
        {
            CelebrationRequest selectedClient = (CelebrationRequest)dgrMain.SelectedItem;

            if (selectedClient != null)
            {
                var ponude = new HCI_T5._4.TabelaPonuda(this.MainWindow, selectedClient);
                ponude.Show();
            }
        }

        private void KlientMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MainWindow.Close();
        }


        private void SearchZahtev_KeyUp(object sender, KeyEventArgs e)
        {
            var searched = Zahtevi.Where(elem => elem.VrstaProslave.ToLower().StartsWith(SearchZahtev.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Zahtevi.Clear();

            foreach (CelebrationRequest cel in this.MainWindow.Zahtevi)
            {
                if (this.MainWindow.loggedUsername == cel.Klijent.Username)
                {
                    Zahtevi.Add(cel);
                }
            }
        }


        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "klijentMainWindow";
            HelpProvider.ShowHelp(str);
        }

        private void Tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                String st = (String)Status.SelectedItem;
                var searched = Zahtevi.Where(elem => elem.Status.ToString().Equals(st));
                dgrMain.ItemsSource = searched;
            
        }

        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String st = (String)Status.SelectedItem;
            var searched = Zahtevi.Where(elem => elem.Status.ToString().Equals(st));
            dgrMain.ItemsSource = searched;
        }
    }
}
