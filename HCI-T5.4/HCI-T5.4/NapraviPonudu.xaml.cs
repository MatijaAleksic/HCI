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
using System.Collections.ObjectModel;

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for NapraviPonudu.xaml
    /// </summary>
    public partial class NapraviPonudu : Window
    {

        public CelebrationRequest Zahtev { get; set; }
        public int budzet;

        //public ObservableCollection<CelebrationRequest> Zahtevi { get; set; }

        public ObservableCollection<Associate> Saradnici { get; set; }
        public ObservableCollection<Product> IzabraniProizvodi { get; set; }

        private MainWindow MainWindow { get; set; }

        public NapraviPonudu()
        {
            InitializeComponent();
        }

        public NapraviPonudu(MainWindow window, CelebrationRequest zah)
        {
            InitializeComponent();

            this.MainWindow = window;
            this.DataContext = this;

            Zahtev = zah;
            budzet = zah.Budzet;

            Saradnici = this.MainWindow.Saradnici;
            IzabraniProizvodi = new ObservableCollection<Product>();
        }

        private void Proizvodi_Click(object sender, RoutedEventArgs e)
        {
            if(Saradnik.SelectedItem != null)
            {
                Associate a = (Associate)Saradnik.SelectedItem;
                var proizvodi = new HCI_T5._4.UpravljajProizvodima(this, a, this.Zahtev.Budzet);
                proizvodi.Show();
            }
            
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Dodaj!");

            Associate a = (Associate)Saradnik.SelectedItem;

            CelebrationOffer offer = new CelebrationOffer(this.Zahtev.Id, a, CelebrationOfferStatus.Ponudjen, this.IzabraniProizvodi.ToList());

            this.MainWindow.Ponude.Add(offer);

            foreach(CelebrationRequest req in this.MainWindow.Zahtevi)
            {
                if(req.Id == this.Zahtev.Id)
                {
                    ++req.BrojPonuda;
                }
            }

            this.MainWindow.util.write_to_file<CelebrationOffer>(this.MainWindow.Ponude, this.MainWindow.pathPonude);

            MessageBox.Show("Uspjesno dodavanje nove ponude!");
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Associate a = (Associate)Saradnik.SelectedItem;
            RasporedSedenja rs = new RasporedSedenja(this.MainWindow, Zahtev, a);
            rs.Show();
        }
    }
}
