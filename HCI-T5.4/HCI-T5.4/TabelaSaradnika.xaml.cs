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
    /// Interaction logic for TabelaSaradnika.xaml
    /// </summary>
    public partial class TabelaSaradnika : Window
    {
        private MainWindow MainWindow { get; set; }
        public ObservableCollection<Associate> Saradnici { get; set; }
        public ObservableCollection<EnterpriseType> Tipovi { get; set; }

        Util util = new Util();

        public TabelaSaradnika()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public TabelaSaradnika(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;

            this.MainWindow = window;

            Saradnici = this.MainWindow.Saradnici;
            Tipovi = this.MainWindow.TipoviPreduzeca;
        }

        private void ObrisiSaradnika_Click(object sender, RoutedEventArgs e)
        {
            Associate selectedAssociate = (Associate)dgrMain.SelectedItem;

            if (selectedAssociate != null)
            {
                foreach (Associate asc in this.MainWindow.Saradnici)
                {
                    if (selectedAssociate.Ime == asc.Ime && selectedAssociate.Adresa == asc.Adresa)
                    {
                        this.MainWindow.Saradnici.Remove(asc);
                        Saradnici.Remove(asc);

                        this.util.write_to_file<Associate>(this.MainWindow.Saradnici, MainWindow.pathSaradnici);
                        break;
                    }
                }
            }
        }

        private void DodajSaradnika_Click(object sender, RoutedEventArgs e)
        {
            DodajSaradnika ds = new DodajSaradnika(this.MainWindow);
            ds.Show();
        }

        private void SearchOrganizator_KeyUp(object sender, KeyEventArgs e)
        {
            var searched = Saradnici.Where(elem => elem.Ime.ToLower().StartsWith(SearchOrganizator.Text.ToLower()) || elem.Adresa.ToLower().StartsWith(SearchOrganizator.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

        private void Tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnterpriseType et =(EnterpriseType)Tip.SelectedItem;
            var searched = Saradnici.Where(elem => elem.Type.Ime.Equals(et.Ime));
            dgrMain.ItemsSource = searched;


        }
    }
}
