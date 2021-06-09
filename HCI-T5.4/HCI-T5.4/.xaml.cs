using HCI_T5._4.modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for DragAndDrop.xaml
    /// </summary>
    public partial class DragAndDrop : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<Guest> Gosti;

        public String ActiveMap { get; set; }
        Point startPoint = new Point();
        private const int picSize = 20;
        private Guest selectedResource;

        public Guest SelectedResource
        {
            get { return selectedResource; }
            set
            {
                if (value != selectedResource)
                {
                    selectedResource = value;
                    OnPropertyChanged("SelectedResource");
                }
            }
        }

        public DragAndDrop()
        {
            ActiveMap = "home-icon.png";
            InitializeComponent();
            this.DataContext = this;

            Map.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Mape\\world_map.png", UriKind.Relative)));
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
