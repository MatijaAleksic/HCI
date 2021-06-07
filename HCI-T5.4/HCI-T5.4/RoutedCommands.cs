using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_T5._4
{
    class RoutedCommands
    {
        public static RoutedUICommand Login = new RoutedUICommand(
           "Otvara login prozor",
           "Login",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
                new KeyGesture(Key.M,ModifierKeys.Control)
           }
           );

        public static RoutedUICommand Register = new RoutedUICommand(
           "Otvara register prozor",
           "Register",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
                new KeyGesture(Key.K,ModifierKeys.Control)
           }
           );

        public static RoutedUICommand TabelaOrganizatora = new RoutedUICommand(
           "Otvara tabelu organizatora",
           "Tabela Organizatora",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
                new KeyGesture(Key.A,ModifierKeys.Control)
           }
           );

        public static RoutedUICommand TabelaKlijenata = new RoutedUICommand(
           "Otvara tabelu klijenata",
           "Tabela Klijenata",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
                new KeyGesture(Key.C,ModifierKeys.Control)
           }
           );

        public static RoutedUICommand TabelaAdministratora = new RoutedUICommand(
           "Otvara tabelu klijenata",
           "Tabela Klijenata",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
                new KeyGesture(Key.C,ModifierKeys.Control)
           }
           );


        public static RoutedUICommand Logout = new RoutedUICommand(
           "Za odjavljivanje korisnika",
           "Logout",
           typeof(RoutedCommand),
           new InputGestureCollection()
           {
                new KeyGesture(Key.B,ModifierKeys.Control)
           }
           );



    }
}
