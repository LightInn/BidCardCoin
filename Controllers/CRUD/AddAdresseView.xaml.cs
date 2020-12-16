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
        private readonly Adresse _adresse;
        private readonly List<string> _listeMotClef;
        private readonly Window _win;


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
            _adresse.Utilisateurs = new List<Utilisateur>();

            AdresseORM.AddAdresse(_adresse);


            _win.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _win.Close();
        }

        private void ViewMotsClefs(object sender, RoutedEventArgs e)
        {
            var window = new Window
            {
                Title = "Liste des mots Clefs",

                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png",
                    UriKind.RelativeOrAbsolute))
            };
            window.Content = new ListeMotsClefsView(window, _listeMotClef);
            window.ShowDialog();


            Console.WriteLine(_listeMotClef);
        }
    }
}