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
    /// Interaction logic for TabelaDogadjaja.xaml
    /// </summary>
    public partial class TabelaDogadjaja : Window
    {
        public TabelaDogadjaja()
        {
            InitializeComponent();
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = "tabelaDogadjaja";
            HelpProvider.ShowHelp(str);
        }

    }
}
