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
using System.IO;

namespace HCI_T5._4
{
    /// <summary>
    /// Interaction logic for RasporedSedenja.xaml
    /// </summary>
    public partial class RasporedSedenja : Window
    {
        public Associate Saradnik { get; set; }
        private MainWindow MainWindow { get; set; }

        public ObservableCollection<Gost> Gosti { get; set; }

        Point startPoint = new Point();
        public String ActiveMap { get; set; }

        public RasporedSedenja()
        {
            InitializeComponent();
        }

        public RasporedSedenja(MainWindow window, CelebrationRequest offer, Associate a)
        {
            ActiveMap = "home-icon.png";
            InitializeComponent();

            this.MainWindow = window;
            this.DataContext = this;

            Saradnik = a;

            Gosti = new ObservableCollection<Gost>(offer.Gosti);


            string curDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string pathO = String.Format("{0}/data/images/home-icon.png", curDir);
            Uri u = new Uri(String.Format("file:///{0}/data/images/home-icon.png", curDir));

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = u;
            bitmap.EndInit();

            ImageViewer1.Source = bitmap;
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }

                current = VisualTreeHelper.GetParent(current);
            } while (current != null);

            return null;
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPos = e.GetPosition(null);
            Vector v = currentPos - startPoint;

            if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(v.X) > SystemParameters.MinimumHorizontalDragDistance && Math.Abs(v.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;

                ListViewItem lvi = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                //GOST BIO 
                Gost a = (Gost)listView.ItemContainerGenerator.ItemFromContainer(lvi);

                DataObject data = new DataObject("gost", a);

                DragDrop.DoDragDrop(lvi, data, DragDropEffects.Copy);
            }
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void MyImage_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("gost") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MyImage_Drop(object sender, DragEventArgs e)
        {
            Point myPoint = e.GetPosition(Map);
            int x = Convert.ToInt32(myPoint.X);
            int y = Convert.ToInt32(myPoint.Y);
            bool f = false;

            bool flag = false;

            if (e.Data.GetDataPresent("gost"))
            {

                Gost arh = e.Data.GetData("gost") as Gost;
                if (!flag)
                {

                    if (!Gosti.Contains(arh))
                    {

                        Dictionary<string, int> d = new Dictionary<string, int>();
                        d.Add(this.ActiveMap, x);

                        Dictionary<string, int> d1 = new Dictionary<string, int>();
                        d1.Add(this.ActiveMap, y);
                        arh.XPoint = d;
                        arh.YPoint = d1;

                        Gosti.Add(arh);
                        foreach (Gost arh1 in Gosti)
                        {
                            this.renderMap(arh1.XPoint[this.ActiveMap], arh1.YPoint[this.ActiveMap], arh1);
                        }

                    }
                }
            }
        }

        public void renderMap(int x, int y, Gost ar)
        {
            string curDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            Uri u = new Uri(String.Format("file:///{0}/data/images/home-icon.png", curDir));

            Image ResourceIcon = new Image();
            ResourceIcon.Width = 30;
            ResourceIcon.Height = 30;

            ResourceIcon.Source = new BitmapImage(u);
            Map.Children.Add(ResourceIcon);
            Canvas.SetLeft(ResourceIcon, x);
            Canvas.SetTop(ResourceIcon, y);

        }

        private void MyImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(Map);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                if (listaGosti.SelectedItems.Count > 0)
                {
                    Map.Children.Clear();
                    Gost arh = Arhitekta_Click((int)mousePos.X, (int)mousePos.Y);
                    Gosti.Remove(arh);
                    DataObject dragData = new DataObject("arhitekta", arh);
                    DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                }
            }
        }

        private Gost Arhitekta_Click(int x, int y)
        {
            foreach (Gost arh in Gosti)
            {
                if (arh.XPoint[this.ActiveMap] != -1 && arh.YPoint[this.ActiveMap] != -1)
                {
                    if (Math.Sqrt(Math.Pow((x - arh.XPoint[this.ActiveMap] - 15), 2) + Math.Pow((y - arh.YPoint[this.ActiveMap] - 15), 2)) < 20)
                    {
                        return arh;
                    }
                }
            }
            return null;

        }

        private void MyImage_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        private void MyImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
