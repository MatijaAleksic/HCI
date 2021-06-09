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
    /// Interaction logic for DetaljiPonude.xaml
    /// </summary>
    public partial class DetaljiPonude : Window
    {

        //public CelebrationRequest Zahtev { get; set; }
        //public int budzet;

        //public ObservableCollection<CelebrationRequest> Zahtevi { get; set; }

        //public ObservableCollection<Associate> Saradnici { get; set; }
        //public ObservableCollection<Product> IzabraniProizvodi { get; set; }

        private MainWindow MainWindow { get; set; }
        public CelebrationOffer Zahtev { get; set; }

        public String Saradnik { get; set; }
        public String Tip { get; set; }
        public String Adresa { get; set; }
        public String Grad { get; set; }
        public int Cena { get; set; }

        public ObservableCollection<Product> Proizvodi { get; set; }

        public DetaljiPonude()
        {
            InitializeComponent();
        }

        public DetaljiPonude(MainWindow window, CelebrationOffer offer)
        {
            InitializeComponent();

            this.MainWindow = window;
            this.DataContext = this;

            Zahtev = offer;

            Saradnik = offer.Saradnik.Ime;
            Tip = offer.Saradnik.Type.Ime;
            Adresa = offer.Saradnik.Adresa;
            Grad = offer.Saradnik.Grad;

            int ukupnaCena = 0;
            foreach(Product p in offer.Proizvodi)
            {
                ukupnaCena = ukupnaCena + p.Cena;
            }
            Cena = ukupnaCena;

            Proizvodi = new ObservableCollection<Product>(offer.Proizvodi);
        }

        private void Prihvati_Click(object sender, RoutedEventArgs e)
        {
            int temp = 0;
            foreach(CelebrationOffer cel in this.MainWindow.Ponude)
            {
                temp = 0;
                foreach (Product p in cel.Proizvodi)
                {
                    temp = temp + p.Cena;
                }

                if (cel.ZahtevIdx == Zahtev.ZahtevIdx && cel.Saradnik.Ime == Saradnik && temp == Cena)
                {
                    cel.Status = CelebrationOfferStatus.Prihvacen;
                }
                else
                {
                    cel.Status = CelebrationOfferStatus.Odbijen;
                }
            }

            foreach (CelebrationRequest cel in this.MainWindow.Zahtevi)
            {

                if (cel.Id == Zahtev.ZahtevIdx)
                {
                    cel.Status = CelebrationRequestStatus.Zavrsen;
                }
            }
        }

        private void Odbaci_Click(object sender, RoutedEventArgs e)
        {
            int temp = 0;
            foreach (CelebrationOffer cel in this.MainWindow.Ponude)
            {
                temp = 0;
                foreach (Product p in cel.Proizvodi)
                {
                    temp = temp + p.Cena;
                }

                if (cel.ZahtevIdx == Zahtev.ZahtevIdx && cel.Saradnik.Ime == Saradnik && temp == Cena)
                {
                    cel.Status = CelebrationOfferStatus.Odbijen;
                }
            }

            foreach (CelebrationRequest cel in this.MainWindow.Zahtevi)
            {

                if (cel.Id == Zahtev.ZahtevIdx)
                {
                    cel.Status = CelebrationRequestStatus.Zavrsen;
                }
            }
        }

    }
}
