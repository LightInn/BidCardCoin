using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BidCardCoin.Models;
using bidCardCoin.ORM;

namespace BidCardCoin.Vue.CRUD
{
    public partial class AddAdresseView : UserControl
    {
        private Adresse _adresse;
        private List<string> _listeMotClef;
        private Window _win;

        public AddAdresseView(Window win = null, Adresse user = null)
        {
            InitializeComponent();
            _win = win;

            _adresse = user ?? new Adresse();
            _listeMotClef = new List<string>();
        }


        private void CreateNewAdresse(object sender, RoutedEventArgs e)
        {
            var uuid = Guid.NewGuid().ToString();
            


            _adresse.IdAdresse = uuid;
            _adresse.Pays = InputPays.Text;
            _adresse.Region = InputRegion.Text;
            _adresse.Ville = InputVille.Text;
            _adresse.CodePostal = InputCodePostal.Text;
            _adresse.AdresseNb = InputAdresse.Text;
            // _adresse.Utilisateurs = InputPassword;
            
            

            
            
            
            // _adresse.IdentityExist = InputIdentity.IsChecked ?? false;
            // _adresse.IsSolvable = InputSolvable.IsChecked ?? false;
            // _adresse.IsRessortissant = InputRessortissant.IsChecked ?? false;
            // _adresse.TelephoneFixe = InputFixe.Text;
            // _adresse.TelephoneMobile = InputMobile.Text;
            // _adresse.ListeMotClef = _listeMotClef;
            // _adresse.Adresses = listeAdresses;


            AdresseORM.AddAdresse(_adresse);
            _win.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _win.Close();
        }

        private void ViewMotsClefs(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Liste des mots Clefs",

                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new ListeMotsClefsView(window, _listeMotClef);
            window.ShowDialog();


            Console.WriteLine(_listeMotClef);
        }
    }
}