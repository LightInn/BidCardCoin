using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BidCardCoin.Models;
using bidCardCoin.ORM;

namespace BidCardCoin.Vue.CRUD
{
    public partial class AddEnchereView : UserControl
    {
        private readonly Enchere _enchere;
        private Utilisateur _utilisateur;
        private readonly Window _win;

        public AddEnchereView(Window win = null, Enchere user = null)
        {
            InitializeComponent();
            _win = win;
            _utilisateur = null;
            _enchere = user ?? new Enchere();
        }


        private void CreateNewEnchere(object sender, RoutedEventArgs e)
        {
            if (InputDateHeureVente.SelectedDate != null ||
                !string.IsNullOrEmpty(InputPrixProposer.Text))
            {
                var uuid = Guid.NewGuid().ToString();

                var lot = new Lot();
                var commissaire = new Commissaire();
                var utilisateur = new Utilisateur();

                _enchere.IdEnchere = uuid;
                _enchere.PrixProposer =
                    int.TryParse(InputPrixProposer.Text, out _) ? int.Parse(InputPrixProposer.Text) : 0;
                _enchere.IsAdjuger = InputIsAdjuger.IsChecked ?? false;
                _enchere.DateHeureVente = InputDateHeureVente.SelectedDate ?? DateTime.Now;


                if (_utilisateur == null) InputOrdreAchat.Text = "ordreAchat1";

                if (string.IsNullOrEmpty(InputLotId.Text)) InputLotId.Text = "lot1";

                if (string.IsNullOrEmpty(InputCommissaireId.Text)) InputCommissaireId.Text = "commissaire1";

                // Donc ça c'est bon
                if (!string.IsNullOrEmpty(InputOrdreAchat.Text))
                    _enchere.OrdreAchatEnchere = OrdreAchatORM.GetOrdreAchatById(InputOrdreAchat.Text);

                if (!string.IsNullOrEmpty(InputLotId.Text)) _enchere.LotEnchere = LotORM.GetLotById(InputLotId.Text);

                if (!string.IsNullOrEmpty(InputCommissaireId.Text))
                    _enchere.CommissaireEnchere = CommissaireORM.GetCommissaireById(InputCommissaireId.Text);


                _enchere.UtilisateurEnchere = _utilisateur;


                EnchereORM.InsertOrAddNewEnchere(_enchere);
                _win.Close();
            }
            else
            {
                MessageBox.Show("Veuillez compléter tout les champs !");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _win.Close();
        }


        private void SelectUtilisateur(object sender, RoutedEventArgs e)
        {
            var userstemp = new List<Utilisateur>();
            if (_utilisateur != null) userstemp.Add(_utilisateur);


            var window = new Window
            {
                Title = "Selectioner un utilisateur",

                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43"),
                Icon = new BitmapImage(new Uri("pack://application:,,,/ressources/CRUDimg/utilisateur.png",
                    UriKind.RelativeOrAbsolute))
            };

            window.Content = new ListeUtilisateursView(window, userstemp);
            window.ShowDialog();

            if (userstemp.Count > 0) _utilisateur = userstemp.First();
        }
    }
}