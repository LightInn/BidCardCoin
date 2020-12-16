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

namespace BidCardCoin.Vue.CRUD
{
    public partial class ListeEncheresView : UserControl
    {
        private string _selectedId;
        private Enchere _contextEnchere;
        private ObservableCollection<Enchere> _encheres;
        private List<Enchere> _selectedEncheres;


        public ListeEncheresView(Window win = null,List<Enchere> selectedEncheres = null)
        {
            InitializeComponent();

            _selectedEncheres = selectedEncheres;

            if (selectedEncheres == null)
            {
                selectMode.Visibility = Visibility.Collapsed;
            }
            
            
            
            _encheres = new ObservableCollection<Enchere>(EnchereORM.GetAllEnchere());
            _contextEnchere = new Enchere();
            GenerateDataList();
            
        }

        private void GenerateDataList()
        {
            ListeEncheresGrid.ItemsSource = _encheres;
            
            
        }



        private void AddEnchere(object sender, RoutedEventArgs e)
        {
            Enchere newEnchere = new Enchere();

            Window window = new Window
            {
                Title = "Ajouter une Enchere",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/enchere.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new AddEnchereView(window, newEnchere);
            window.ShowDialog();
            if (newEnchere.IdEnchere != null)
            {
                _encheres.Add(newEnchere);
            }
        }

        private void DeleteEnchere(object sender, RoutedEventArgs e)
        {
            if (ListeEncheresGrid.SelectedIndex >= 0 && ListeEncheresGrid.SelectedIndex < _encheres.Count)
            {
                EnchereORM.DeleteEnchere(_encheres.ElementAt(ListeEncheresGrid.SelectedIndex));
                _encheres.RemoveAt(ListeEncheresGrid.SelectedIndex);
            }
        }

        private void SelectEnchere(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditEnchere(object sender, RoutedEventArgs e)
        {
            Enchere selectedEnchere = _encheres[ListeEncheresGrid.SelectedIndex];

            Window window = new Window
            {
                Title = "Ajouter une Enchere",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/enchere.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new EditEnchereView(window, selectedEnchere);
            window.ShowDialog();
           
        }
    }
}