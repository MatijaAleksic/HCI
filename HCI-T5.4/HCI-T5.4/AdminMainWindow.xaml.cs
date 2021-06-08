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

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private MainWindow MainWindow { get; set; }


        public AdminMainWindow()
        {
            InitializeComponent();
        }

        public AdminMainWindow(MainWindow window)
        {
            InitializeComponent();
            this.MainWindow = window;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new HCI_T5._4.Login(this.MainWindow);
            login.Show();
            this.Close();
        }

        private void Organizatori_Click(object sender, RoutedEventArgs e)
        {
            var s = new TabelaOrganizatora(this.MainWindow);
            s.Show();
        }

        private void Klijent_Click(object sender, RoutedEventArgs e)
        {
            var s = new TabelaKlijenata(this.MainWindow);
            s.Show();
        }

        private void Saradnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new TabelaSaradnika(this.MainWindow);
            s.Show();
        }
        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            var s = new TabelaAdministratora(this.MainWindow);
            s.Show();
        }

        private void AdminMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MainWindow.Close();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
