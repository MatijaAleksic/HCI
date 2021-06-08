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
    /// Interaction logic for OrganiserMainWindow.xaml
    /// </summary>
    public partial class OrganiserMainWindow : Window
    {
        private MainWindow MainWindow { get; set; }
        public ObservableCollection<Associate> Saradnici { get; set; }
        public OrganiserMainWindow()
        {
            InitializeComponent();
        }

        public OrganiserMainWindow(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MainWindow = window;

            Saradnici = this.MainWindow.Saradnici;
        }

        private void Saradnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new TabelaSaradnika(this.MainWindow);
            s.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new HCI_T5._4.Login(this.MainWindow);
            login.Show();
            this.Close();
        }
    }
}
