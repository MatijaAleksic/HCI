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
    /// Interaction logic for TabelaKlijenata.xaml
    /// </summary>
    public partial class TabelaKlijenata : Window
    {
        private MainWindow MainWindow { get; set; }
        public ObservableCollection<Client> Klijenti { get; set; }

        Util util = new Util();

        public TabelaKlijenata()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public TabelaKlijenata(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;

            this.MainWindow = window;

            Klijenti = this.MainWindow.Klijenti;
        }

        private void ObrisiKlijenta_Click(object sender, RoutedEventArgs e)
        {
            Client selectedClient = (Client)dgrMain.SelectedItem;

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
            }
        }

        private void SearchOrganizator_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var searched = Klijenti.Where(elem => elem.Ime.ToLower().StartsWith(SearchOrganizator.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

        private void DodajKlijenta_Click(object sender, RoutedEventArgs e)
        {
            RegistracijaKorisnik rk = new RegistracijaKorisnik(this.MainWindow);
            rk.Show();
        }
    }
}
