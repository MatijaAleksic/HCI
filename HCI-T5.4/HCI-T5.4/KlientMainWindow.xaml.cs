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
            
            Zahtevi = this.MainWindow.Zahtevi;

            /*Client c = new Client("asdf", "asdf", "asdf", "asdf", "asdf");

            EnterpriseType type = new EnterpriseType("Tip1");

            Product p1 = new Product("prdukt1", 100);
            Product p2 = new Product("prdukt2", 200);
            Product p3 = new Product("prdukt3", 300);

            List<Product> productList = new List<Product> { p1, p2, p3 };

            Associate aso = new Associate("asdf", type, "adresa", "grad", productList);

            CelebrationRequest a = new CelebrationRequest("asd", 100, DateTime.Now, "asdf", "asdf", CelebrationRequestStatus.Cekanje, 0, c, aso);

            this.MainWindow.Zahtevi.Add(a);

            this.MainWindow.util.write_to_file<CelebrationRequest>(this.MainWindow.Zahtevi, this.MainWindow.pathZahtevi);*/
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new HCI_T5._4.Login(this.MainWindow);
            login.Show();
            this.Close();
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
