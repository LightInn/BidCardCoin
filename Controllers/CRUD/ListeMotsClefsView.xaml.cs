using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BidCardCoin.Models;
using bidCardCoin.ORM;
using Microsoft.VisualBasic;

//todo Hyper Chiant :  Passer en mode select si on transmet une liste

namespace BidCardCoin.Vue.CRUD
{
    public partial class ListeMotsClefsView : UserControl
    {
        private string _selectedId;
        private List<string> _motsClefs;


        public ListeMotsClefsView(Window win = null, List<string> listeMotsClefs = null)
        {
            InitializeComponent();

            _motsClefs = listeMotsClefs;
            GenerateDataList();
        }


        private void GenerateDataList()
        {
            MotsClefsListBox.ItemsSource = _motsClefs;
        }

        private void ListeMotsClefsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void AddMotClef(object sender, RoutedEventArgs e)
        {
            String newMotClef = "";
            Window window = new Window
            {
                Title = "Ajouter un Mot Clef",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new AddMotClefView(window, _motsClefs);
            window.ShowDialog();
            GenerateDataList();
        }

        private void RemoveMotClef(object sender, RoutedEventArgs e)
        {
            if (MotsClefsListBox.SelectedIndex >= 0 && MotsClefsListBox.SelectedIndex < _motsClefs.Count)
            {
                _motsClefs.RemoveAt(MotsClefsListBox.SelectedIndex);
            }
        }
    }
}