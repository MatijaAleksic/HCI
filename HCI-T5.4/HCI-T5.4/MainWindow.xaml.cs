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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Drawing;

using System.Collections.ObjectModel;

using Newtonsoft.Json;
using System.IO;

using HCI_T5._4.modeli;


namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Admin> Administratori { get; set; }

        //ObservableCollection<Admin> _administratori { get; set; }
        //public ObservableCollection<Admin> Administratori { get => _administratori; set => _administratori = value; }


        public MainWindow()
        {

            this.Hide();

            string pathAdministratora = @"..\..\..\data\administratori.txt";

            List<Admin> admini = new List<Admin>();

            using (StreamReader r = new StreamReader(pathAdministratora))
            {
                string json = r.ReadToEnd();
                admini = JsonConvert.DeserializeObject<List<Admin>>(json);
                r.Close();
            }
            Administratori =  new ObservableCollection<Admin>(admini);

            var login = new HCI_T5._4.Login(this);
            login.Show();
        }





        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var login = new HCI_T5._4.Login(this);
            //login.DataContext = this;
            //login.Show();
        }
    }
}
