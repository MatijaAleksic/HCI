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
    /// Interaction logic for TabelaAdministratora.xaml
    /// </summary>
    public partial class TabelaAdministratora : Window
    {
        private MainWindow MainWindow { get; set; }
        public ObservableCollection<Admin> Administratori { get; set; }

        Util util = new Util();

        public TabelaAdministratora()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public TabelaAdministratora(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;

            this.MainWindow = window;

            Administratori = this.MainWindow.Administratori;
        }

        private void ObrisiAdministratora_Click(object sender, RoutedEventArgs e)
        {
            Admin selectedAdmin = (Admin)dgrMain.SelectedItem;

            if (selectedAdmin != null)
            {
                foreach (Admin adm in this.MainWindow.Administratori)
                {
                    if (selectedAdmin.Username == adm.Username && selectedAdmin.Email == adm.Email)
                    {
                        this.MainWindow.Administratori.Remove(adm);
                        Administratori.Remove(adm);

                        this.util.write_to_file<Admin>(this.MainWindow.Administratori, MainWindow.pathAdministratora);
                        break;
                    }
                }
            }
        }

        private void SearchOrganizator_KeyUp(object sender, KeyEventArgs e)
        {
            var searched = Administratori.Where(elem => elem.Ime.ToLower().StartsWith(SearchOrganizator.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

        private void DodajKlijenta_Click(object sender, RoutedEventArgs e)
        {
            RegistracijaAdmin ra = new RegistracijaAdmin(this.MainWindow);
            ra.Show();
        }
    }
}
