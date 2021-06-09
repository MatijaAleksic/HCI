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
    /// Interaction logic for TabelaPonuda.xaml
    /// </summary>
    public partial class TabelaPonuda : Window
    {

        private MainWindow MainWindow { get; set; }
        public ObservableCollection<CelebrationOffer> Ponude { get; set; }
        public ObservableCollection<CelebrationRequestStatus> Statusi { get; set; }

        public TabelaPonuda()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public TabelaPonuda(MainWindow window, CelebrationRequest celeb)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MainWindow = window;

            Ponude = new ObservableCollection<CelebrationOffer>();

            foreach (CelebrationOffer cel in this.MainWindow.Ponude)
            {
                if (celeb.Id == cel.ZahtevIdx)
                {
                    Ponude.Add(cel);
                }
            }

            Statusi.Add(CelebrationRequestStatus.Podnesen);
            Statusi.Add(CelebrationRequestStatus.Cekanje);
            Statusi.Add(CelebrationRequestStatus.Zavrsen);

        }

        private void SearchZahtev_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var searched = Ponude.Where(elem => elem.Saradnik.Ime.ToLower().StartsWith(SearchZahtev.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

        private void Tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CelebrationRequestStatus st = (CelebrationRequestStatus) Status.SelectedItem;
            var searched = Ponude.Where(elem => elem.Status.ToString().Equals(st.ToString()));
            dgrMain.ItemsSource = searched;
        }
    }
}
