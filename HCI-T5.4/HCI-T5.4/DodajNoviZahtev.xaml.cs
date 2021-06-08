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
using System.Text.RegularExpressions;
using HCI_T5._4.modeli;
using System.Collections.ObjectModel;

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for DodajNoviZahtev.xaml
    /// </summary>
    public partial class DodajNoviZahtev : Window
    {
        private MainWindow MainWindow { get; set; }

        public ObservableCollection<Organiser> Organizatori { get; set; }

        public DodajNoviZahtev()
        {
            InitializeComponent();
        }

        public DodajNoviZahtev(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MainWindow = window;

            Organizatori = this.MainWindow.Organizatori;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            ++this.MainWindow.zahtev_idx;
            CelebrationRequest temp = new CelebrationRequest(this.MainWindow.zahtev_idx,VrstaProslave.Text, Int32.Parse(Budzet.Text), Datum.DisplayDate, Grad.Text, Proizvodi.Text, CelebrationRequestStatus.Cekanje, 0, new Client("a", "a", "a", "a", "a"), (Organiser) Organizator.SelectedItem);

            this.MainWindow.Zahtevi.Add(temp);

            this.MainWindow.util.write_to_file<CelebrationRequest>(this.MainWindow.Zahtevi, this.MainWindow.pathZahtevi);

            MessageBox.Show("Uspjesno dodavanje novog zahteva!");
            this.Close();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

}
}
