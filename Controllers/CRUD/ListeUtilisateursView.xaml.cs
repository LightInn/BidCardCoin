﻿using System;
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
        // private ObservableCollection<Adresse> _adresses;

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
            // ComboBoxColumnAdresse.ItemsSource = _adresses;
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
            if (newUser.IdUtilisateur != null)
            {
                _utilisateurs.Add(newUser);
                // foreach (var utilisateur in _utilisateurs)
                // {
                //     foreach (var adress in utilisateur.Adresses)
                //     {
                //         _adresses.Add(adress);
                //     }
                // }
            }
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

        private void EditUser(object sender, RoutedEventArgs e)
        {
            Utilisateur selectedUser = _utilisateurs[ListeUtilisateursGrid.SelectedIndex];

            Window window = new Window
            {
                Title = "Modifier un utilisateur",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new EditUtilisateurView(window, selectedUser);
            window.ShowDialog();
        }
    }
}