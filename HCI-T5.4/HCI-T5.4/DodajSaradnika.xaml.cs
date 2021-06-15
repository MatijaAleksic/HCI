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
    /// Interaction logic for DodajSaradnika.xaml
    /// </summary>
    public partial class DodajSaradnika : Window
    {

        private MainWindow MainWindow { get; set; }
        string pathSaradnika = @"..\..\..\data\saradnici.txt";

        public ObservableCollection<EnterpriseType> Tipovi { get; set; }
        public DodajSaradnika()
        {
            InitializeComponent();
        }

        public DodajSaradnika(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MainWindow = window;

            Tipovi = this.MainWindow.TipoviPreduzeca;
        }

        private void DodajSardnika_Click(object sender, RoutedEventArgs e)
        {
            Boolean uspesno = true;
            Util util = new Util();

            foreach (Associate associate in this.MainWindow.Saradnici)
            {
                if (associate.Ime.Equals(Ime.Text) && associate.Adresa.Equals(Adresa.Text))
                {
                    uspesno = false;
                    MessageBox.Show("Saradnik sa ovim kredencijalima vec postoji!");
                    break;
                }
            }
            if (uspesno)
            {
                Associate newAssociate = new Associate(Ime.Text, (EnterpriseType)Tip.SelectedItem, Adresa.Text, Grad.Text, null, null);

                this.MainWindow.Saradnici.Add(newAssociate);

                util.write_to_file<Associate>(this.MainWindow.Saradnici, pathSaradnika);

                MessageBox.Show("Uspesno dodat saradnik");
                this.Close();
            }
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "DodavanjeSaradnika";
            HelpProvider.ShowHelp(str);
        }
    }
}
