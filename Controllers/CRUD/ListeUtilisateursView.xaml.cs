using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private List<Utilisateur> _selectedUsers;


        public ListeUtilisateursView(Window win = null, List<Utilisateur> selectedUsers = null)
        {
            InitializeComponent();
            
            
            
            
            _selectedUsers = selectedUsers;
            if (selectedUsers == null)
            {
                selectMode.Visibility = Visibility.Collapsed;
            }

           

            _utilisateurs = new ObservableCollection<Utilisateur>(UtilisateurORM.GetAllUtilisateur());
            _contextUtilisateur = new Utilisateur();
            GenerateDataList();
        }

        private void GenerateDataList()
        {
            ListeUtilisateursGrid.ItemsSource = _utilisateurs;
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
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new AddUtilisateurView(window, newUser);
            window.ShowDialog();

            _utilisateurs.Add(newUser);
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (ListeUtilisateursGrid.SelectedIndex >= 0 && ListeUtilisateursGrid.SelectedIndex < _utilisateurs.Count)
            {
                UtilisateurORM.DeleteUtilisateur(_utilisateurs.ElementAt(ListeUtilisateursGrid.SelectedIndex));
                _utilisateurs.RemoveAt(ListeUtilisateursGrid.SelectedIndex);
            }
        }

        private void SelectUser(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}