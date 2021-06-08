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

        public KlientMainWindow()
        {
            InitializeComponent();

        }

        public KlientMainWindow(MainWindow window)
        {
            InitializeComponent();

            this.DataContext = this;
            this.MainWindow = window;


            Zahtevi = new ObservableCollection<CelebrationRequest>();

            foreach (CelebrationRequest cel in this.MainWindow.Zahtevi)
            {
                if (this.MainWindow.loggedUsername == cel.Klijent.Username)
                {
                    Zahtevi.Add(cel);
                }
            }
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

            /*Client selectedClient = (Client)dgrMain.SelectedItem;

            if (selectedClient != null)
            {
                foreach (Client cli in this.MainWindow.Klijenti)
                {
                    if (selectedClient.Username == cli.Username && selectedClient.Email == cli.Email)
                    {
                        this.MainWindow.Klijenti.Remove(cli);
                        Klijenti.Remove(cli);

                        this.util.write_to_file<Client>(this.MainWindow.Klijenti, MainWindow.pathKlijenata);
                        break;
                    }
                }
            }*/
        }

        private void KlientMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MainWindow.Close();
        }


        private void SearchZahtev_KeyUp(object sender, KeyEventArgs e)
        {
            var searched = Zahtevi.Where(elem => elem.Grad.ToLower().StartsWith(SearchZahtev.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

    }
}
