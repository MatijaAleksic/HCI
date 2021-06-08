using HCI_T5._4.modeli;
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
    /// Interaction logic for RegistracijaOrganizatora.xaml
    /// </summary>
    public partial class RegistracijaOrganizatora : Window
    {
        private MainWindow MainWindow { get; set; }
        string pathOrganizatora = @"..\..\..\data\organizatori.txt";

        public RegistracijaOrganizatora()
        {
            InitializeComponent();
        }

        public RegistracijaOrganizatora(MainWindow window)
        {
            InitializeComponent();
            this.MainWindow = window;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Boolean uspesno = true;
            Util util = new Util();

            foreach (Organiser orga in this.MainWindow.Organizatori)
            {
                if (orga.Username.Equals(Username.Text) || orga.Email.Equals(Email.Text))
                {
                    uspesno = false;
                    MessageBox.Show("Organizator sa ovim kredencijalima vec postoji!");
                    break;
                }
            }
            if (uspesno)
            {
                Organiser newOrganiser = new Organiser(Firstname.Text, Lastname.Text, Email.Text, Username.Text, Password.Password);

                this.MainWindow.Organizatori.Add(newOrganiser);

                util.write_to_file<Organiser>(this.MainWindow.Organizatori, pathOrganizatora);

                MessageBox.Show("Uspjesna registracija!");
                this.Close();
            }
        }
    }
}
