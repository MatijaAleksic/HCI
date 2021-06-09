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
    /// Interaction logic for DodajProizvod.xaml
    /// </summary>
    public partial class DodajProizvod : Window
    {
        private MainWindow MainWindow { get; set; }
        string pathProizvoda = @"..\..\..\data\saradnici.txt";
        public ObservableCollection<Associate> Saradnici { get; set; }

        public Associate saradnik { get; set; }

        public DodajProizvod()
        {
            InitializeComponent();
        }
        public DodajProizvod(MainWindow window,Associate selectedAssociate)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MainWindow = window;

            saradnik = selectedAssociate;
            Saradnici = new ObservableCollection<Associate>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
