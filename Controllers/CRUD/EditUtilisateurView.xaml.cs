using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using bidCardCoin.DAL;
using BidCardCoin.Models;
using bidCardCoin.ORM;

namespace BidCardCoin.Vue.CRUD
{
    public partial class EditUtilisateurView : UserControl
    {
        private Utilisateur _user;
        private List<string> _listeMotClef;
        private Window _win;
        List<Adresse> _listeAdresses;

        public EditUtilisateurView(Window win, Utilisateur user)
        {
            InitializeComponent();
            _win = win;
        }


        private void EditUtilisateur(object sender, RoutedEventArgs e)
        {
            if (InputAge.Text != "" || InputEmail.Text != "" || InputFixe.Text != "" || InputNom.Text != "")
            {
                var uuid = Guid.NewGuid().ToString();
                var idPersonne = Guid.NewGuid().ToString();
                
                InputNom.Text = _user.Nom ;
                InputPrenom.Text = _user.Prenom ;
                InputAge.Text = _user.Age.ToString() ;
                InputEmail.Text = _user.Email ;
                InputPassword.Password = _user.Password ;
                InputIdentity.IsChecked = _user.IdentityExist ;
                InputSolvable.IsChecked = _user.IsSolvable ;
                InputRessortissant.IsChecked = _user.IsRessortissant ;
                InputFixe.Text = _user.TelephoneFixe ;
                InputMobile.Text = _user.TelephoneMobile ;
                _listeMotClef = _user.ListeMotClef ;
                _listeAdresses = _user.Adresses ;
                
                UtilisateurORM.UpdateUtilisateur(_user);
                _win.Close();
            }
            else
            {
                MessageBox.Show("Veulliez completer tout les champs");
            }

         
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _win.Close();
        }

        private void ViewMotsClefs(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Selection adresses",

                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/adresse.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new ListeMotsClefsView(window, _listeMotClef);
            window.ShowDialog();
        }

        private void SelectAdresses(object sender, RoutedEventArgs e)
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

            window.Content = new ListeAdressesView(window, _listeAdresses);
            window.ShowDialog();
        }
    }
}