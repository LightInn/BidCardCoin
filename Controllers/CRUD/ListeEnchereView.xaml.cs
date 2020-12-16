using System;
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


        public ListeEncheresView(Window win = null)
        {
            InitializeComponent();

            _encheres = new ObservableCollection<Enchere>(EnchereORM.GetAllEnchere());
            _contextEnchere = new Enchere();
            GenerateDataList();
        }

        private void GenerateDataList()
        {
            ListeEncheresGrid.ItemsSource = _encheres;
        }

        private void ListeEncheresGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
    }
}