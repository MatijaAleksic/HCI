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


using System.Data;



namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for TabelaOrganizatora.xaml
    /// </summary>
    public partial class TabelaOrganizatora : Window
    {
        private MainWindow MainWindow { get; set; }
        public ObservableCollection<Organiser> Organizatori { get;  set; }

        Util util = new Util();

        public TabelaOrganizatora()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public TabelaOrganizatora(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;

            this.MainWindow = window;

            Organizatori = this.MainWindow.Organizatori;
        }

        private void ObrisiOrganizatora_Click(object sender, RoutedEventArgs e)
        {
            Organiser selectedOrganiser = (Organiser)dgrMain.SelectedItem;

            if (MessageBox.Show("Da li ste sigurni da zelite da obrisete organizatora?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                Close();
            }
            else
            {
                if (selectedOrganiser != null)
                {
                    foreach (Organiser org in this.MainWindow.Organizatori)
                    {
                        if (selectedOrganiser.Username == org.Username && selectedOrganiser.Email == org.Email)
                        {
                            this.MainWindow.Organizatori.Remove(org);
                            Organizatori.Remove(org);

                            this.util.write_to_file<Organiser>(this.MainWindow.Organizatori, MainWindow.pathOrganizatora);
                            break;
                        }
                    }
                }
            }
        }

        private void SearchOrganizator_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var searched = Organizatori.Where(elem => elem.Ime.ToLower().StartsWith(SearchOrganizator.Text.ToLower()));

            dgrMain.ItemsSource = searched;
        }

        private void DodajKlijenta_Click(object sender, RoutedEventArgs e)
        {
            RegistracijaOrganizatora ro = new RegistracijaOrganizatora(this.MainWindow);
            ro.Show();
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "TabelaOrganizatora";
            HelpProvider.ShowHelp(str);
        }
    }
}
