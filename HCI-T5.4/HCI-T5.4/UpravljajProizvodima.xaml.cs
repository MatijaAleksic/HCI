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
using System.ComponentModel;

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for UpravljajProizvodima.xaml
    /// </summary>
    /// 

    //public ObservableCollection<Organiser> Organizatori { get; set; }

    //public ObservableCollection<Gost> Gosti { get; set; }

    public partial class UpravljajProizvodima : Window
    {
        private NapraviPonudu NapraviPonudu { get; set; }
        private Associate Saradnik { get; set; }

        private int _budzet;

        public ObservableCollection<Product> ProizvodiLevo { get; set; }
        public ObservableCollection<Product> ProizvodiDesno { get; set; }


        public UpravljajProizvodima()
        {
            InitializeComponent();
        }

        public UpravljajProizvodima(NapraviPonudu window, Associate saradnik, int budzet) //MainWindow window)
        {
            InitializeComponent();
            this.DataContext = this;

            this.NapraviPonudu = window;
            this.Saradnik = saradnik;
            this.ProizvodiDesno = this.NapraviPonudu.IzabraniProizvodi;
            this._budzet = budzet;
            
            ProizvodiLevo = new ObservableCollection<Product>(saradnik.Proizvodi);

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProizvod = (Product)LevoPro.SelectedItem;

            if (selectedProizvod != null)
            {
                if ((this.Budzet - selectedProizvod.Cena) > 0)
                {
                    this.NapraviPonudu.IzabraniProizvodi.Add(selectedProizvod);
                    this.Budzet = this.Budzet - selectedProizvod.Cena;
                }
                else
                {
                    MessageBox.Show("Nemate dovoljno novca u budzetu");
                }
            }
        }


        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProizvod = (Product)DesnoPro.SelectedItem;
            if (selectedProizvod != null)
            {
                this.NapraviPonudu.IzabraniProizvodi.Remove(selectedProizvod);
                this.Budzet = this.Budzet + selectedProizvod.Cena;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Budzet
        {
            get { return _budzet; }
            set
            {
                if (value != _budzet)
                {
                    _budzet = value;
                    OnPropertyChanged("Budzet");
                }
            }
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "upravljajProizvodima";
            HelpProvider.ShowHelp(str);
        }


    }
}
