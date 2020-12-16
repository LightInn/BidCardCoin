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
    public partial class ListeAdressesView : UserControl
    {
        private string _selectedId;
        private Adresse _contextAdresse;
        private ObservableCollection<Adresse> _adressess;
        private List<Adresse> _selectedAdresses;

        public ListeAdressesView(Window win = null, List<Adresse> adresses = null)
        {
            InitializeComponent();


            _selectedAdresses = adresses;
            if (_selectedAdresses == null)
            {
                selectMode.Visibility = Visibility.Collapsed;
            }


            _adressess = new ObservableCollection<Adresse>(AdresseORM.GetAllAdresse());
            _contextAdresse = new Adresse();

            GenerateDataList();
        }

        private void GenerateDataList()
        {
            ListeAdressesGrid.ItemsSource = _adressess;

            if (_selectedAdresses != null)
            {
                foreach (var selectedAdress in _selectedAdresses)
                {
                    ListeAdressesGrid.SelectedItems.Add(ListeAdressesGrid.Items[_adressess.IndexOf(_adressess.First(adress => adress.IdAdresse == selectedAdress.IdAdresse))]);
                }
            }
        }

        private void ListeAdressesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void AddAdresse(object sender, RoutedEventArgs e)
        {
            Adresse newAdresse = new Adresse();

            Window window = new Window
            {
                Title = "Ajouter une Adresse",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png",
                    UriKind.RelativeOrAbsolute)),
            };
            window.Content = new AddAdresseView(window, newAdresse);
            window.ShowDialog();
            _adressess.Add(newAdresse);
        }

        private void DeleteAdresse(object sender, RoutedEventArgs e)
        {
            if (ListeAdressesGrid.SelectedIndex >= 0 && ListeAdressesGrid.SelectedIndex < _adressess.Count)
            {
                AdresseORM.DeleteAdresse(_adressess.ElementAt(ListeAdressesGrid.SelectedIndex));
                _adressess.RemoveAt(ListeAdressesGrid.SelectedIndex);
            }
        }

        private void SelectAdresses(object sender, RoutedEventArgs e)
        {
            if (ListeAdressesGrid.SelectedIndex != -1)
            {
                _selectedAdresses.Clear();
                foreach (var adress in new List<Adresse>(ListeAdressesGrid.SelectedItems.Cast<Adresse>()))
                {
                    _selectedAdresses.Add(adress);
                }
            }
        }
    }
}