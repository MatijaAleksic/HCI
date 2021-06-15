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
using HCI_T5._4.modeli;

using System.Collections.ObjectModel;

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for TabelaGostiju.xaml
    /// </summary>
    public partial class TabelaGostiju : Window
    {

        public ObservableCollection<Gost> Gosti { get; set; }

        private DodajNoviZahtev DodajNoviZahtev { get; set; }

        public TabelaGostiju()
        {
            InitializeComponent();
        }

        public TabelaGostiju(DodajNoviZahtev window)
        {
            InitializeComponent();
            this.DataContext = this;
            this.DodajNoviZahtev = window;
            Gosti = window.Gosti;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                Boolean ima = false;

                foreach (Gost g in this.DodajNoviZahtev.Gosti.ToList())
                {
                    if (textBox1.Text == g.Ime)
                    {
                        ima = true;
                    }
                }
                if (!ima)
                {
                    Gost noviGost = new Gost(textBox1.Text);
                    this.DodajNoviZahtev.Gosti.Add(noviGost);
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Gost selectedGost = (Gost)ListGosti.SelectedItem;

            foreach (Gost g in this.DodajNoviZahtev.Gosti.ToList())
            {
                if(selectedGost.Ime == g.Ime )
                {
                    this.DodajNoviZahtev.Gosti.Remove(g);
                }
            }
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "tabelaGostiju";
            HelpProvider.ShowHelp(str);
        }


    }
}
