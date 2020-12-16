using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<Adresse> _adressess;
        private List<Adresse> _selectedAdresses;

        public EditUtilisateurView(Window win=null, Utilisateur user=null)
        {
            _user = user;
            InitializeComponent();
            GenerateGrid();
            _win = win;
        }


        private void EditUtilisateur(object sender, RoutedEventArgs e)
        {
            if (InputAge.Text != "" || InputEmail.Text != "" || InputFixe.Text != "" || InputNom.Text != "")
            {
                
                _user.Nom = InputNom.Text;
                _user.Prenom = InputPrenom.Text;
                _user.Age = int.TryParse(InputAge.Text, out _) ? int.Parse(InputAge.Text) : 20;
                _user.Email = InputEmail.Text;
                _user.Password = InputPassword.Password;
                _user.IdentityExist = InputIdentity.IsChecked ?? false;
                _user.IsSolvable = InputSolvable.IsChecked ?? false;
                _user.IsRessortissant = InputRessortissant.IsChecked ?? false;
                _user.TelephoneFixe = InputFixe.Text;
                _user.TelephoneMobile = InputMobile.Text;
                _user.ListeMotClef = _listeMotClef;
                _user.Adresses = _listeAdresses;
                
                UtilisateurORM.UpdateUtilisateur(_user);
                _win.Close();
            }
            else
            {
                MessageBox.Show("Veulliez completer tout les champs");
            }

         
        }

        private void GenerateGrid()
        {
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