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
    public partial class EditEnchereView : UserControl
    {
        private readonly Enchere _enchere;
        private Utilisateur _utilisateur;
        private readonly Window _win;

        public EditEnchereView(Window win = null, Enchere enchere = null)
        {
            _enchere = enchere ?? new Enchere();
            InitializeComponent();
            GenerateControle();
            _win = win;
            _utilisateur = _enchere.UtilisateurEnchere;
        }

        private void GenerateControle()
        {
            InputPrixProposer.Text = _enchere.PrixProposer.ToString();
            InputIsAdjuger.IsChecked = _enchere.IsAdjuger;
            InputDateHeureVente.SelectedDate = _enchere.DateHeureVente;
            if (_enchere.UtilisateurEnchere == null)
                InputOrdreAchat.Text = "ordreAchat1";
            else
                _utilisateur = _enchere.UtilisateurEnchere;

            InputLotId.Text = "lot1";
            InputCommissaireId.Text = "commissaire1";
        }


        private void ModifyEnchere(object sender, RoutedEventArgs e)
        {
            if (InputDateHeureVente.SelectedDate != null ||
                !string.IsNullOrEmpty(InputPrixProposer.Text))
            {
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


                EnchereORM.UpadateEnchere(_enchere);
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