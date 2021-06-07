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
    /// Interaction logic for TabelaProizvoda.xaml
    /// </summary>
    public partial class TabelaProizvoda : Window
    {
        public ObservableCollection<Product> Products
        {
            get;
            set;
        }
        public TabelaProizvoda()
        {
            InitializeComponent();
            this.DataContext = this;
            Products = new ObservableCollection<Product>();
            Products.Add(new Product {Id="1", Ime = "Petar", Opis = "Petrovic"});
            Products.Add(new Product { Id = "1", Ime = "Milica", Opis = "Milicevic" });
            Products.Add(new Product { Id = "1", Ime = "Zoran", Opis = "Zoranovic" });
            Products.Add(new Product { Id = "1", Ime = "Suzana", Opis = "Suzanic" });
            Products.Add(new Product { Id = "1", Ime = "Goran", Opis = "Goranski"});
        }
    }
}
