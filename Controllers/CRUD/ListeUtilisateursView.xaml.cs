using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BidCardCoin.Models;
using bidCardCoin.ORM;

//todo Hyper Chiant :  Passer en mode select si on transmet une liste

namespace BidCardCoin.Vue.CRUD
{
    public partial class ListeUtilisateursView : UserControl
    {
        private string _selectedId;
        private Utilisateur _contextUtilisateur;
        private ObservableCollection<Utilisateur> _utilisateurs;


        public ListeUtilisateursView(Window win = null)
        {
            InitializeComponent();
       
            _utilisateurs = new ObservableCollection<Utilisateur>(UtilisateurORM.GetAllUtilisateur());
            _contextUtilisateur = new Utilisateur();
            GenerateDataList();
        }

        private void GenerateDataList()
        {
            
            
            ListeUtilisateursGrid.ItemsSource = _utilisateurs;
            

        }

        private void ListeUtilisateursGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {

            
            Utilisateur newUser = new Utilisateur();
            
            Window window = new Window
            {
                Title = "Ajouter un utilisateur",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png", UriKind.RelativeOrAbsolute)),
                
            };
            window.Content = new AddUtilisateurView(window,newUser);
            window.ShowDialog();

        }
    }
}