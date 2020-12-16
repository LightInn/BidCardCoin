using System;
using System.Collections.Generic;
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
        private Enchere _enchere;
        private Window _win;

        public AddEnchereView(Window win = null, Enchere user = null)
        {
            InitializeComponent();
            _win = win;

            _enchere = user ?? new Enchere();
        }


        private void CreateNewEnchere(object sender, RoutedEventArgs e)
        {
            if (InputDateHeureVente.SelectedDate != null ||
                !string.IsNullOrEmpty(InputPrixProposer.Text))
            {
                var uuid = Guid.NewGuid().ToString();

                Lot lot = new Lot();
                Commissaire commissaire = new Commissaire();
                Utilisateur utilisateur = new Utilisateur();

                _enchere.IdEnchere = uuid;
                _enchere.PrixProposer =
                    int.TryParse(InputPrixProposer.Text, out _) ? int.Parse(InputPrixProposer.Text) : 0;
                _enchere.IsAdjuger = InputIsAdjuger.IsChecked ?? false;
                _enchere.DateHeureVente = InputDateHeureVente.SelectedDate ?? DateTime.Now;

                // Condition provisoire, pour éviter qu'on est des données nulles et autres problèmes dût à la non implémentation du reste.
                if (string.IsNullOrEmpty(InputOrdreAchat.Text) && string.IsNullOrEmpty(InputUtilisateur.Text))
                {
                    InputOrdreAchat.Text = "ordreAchat1";
                    InputUtilisateur.Text = null;
                }
                else
                {
                    if (string.IsNullOrEmpty(InputOrdreAchat.Text))
                    {
                        InputOrdreAchat.Text = "ordreAchat1";
                    }

                    if (string.IsNullOrEmpty(InputUtilisateur.Text))
                    {
                        InputUtilisateur.Text = "utilisateur1";
                    }
                }

                if (string.IsNullOrEmpty(InputLotId.Text))
                {
                    InputLotId.Text = "lot1";
                }

                if (string.IsNullOrEmpty(InputCommissaireId.Text))
                {
                    InputCommissaireId.Text = "commissaire1";
                }

                // Donc ça c'est bon
                if (!string.IsNullOrEmpty(InputOrdreAchat.Text))
                {
                    _enchere.OrdreAchatEnchere = OrdreAchatORM.GetOrdreAchatById(InputOrdreAchat.Text);
                }

                if (!string.IsNullOrEmpty(InputLotId.Text))
                {
                    _enchere.LotEnchere = LotORM.GetLotById(InputLotId.Text);
                }

                if (!string.IsNullOrEmpty(InputCommissaireId.Text))
                {
                    _enchere.CommissaireEnchere = CommissaireORM.GetCommissaireById(InputCommissaireId.Text);
                }

                if (!string.IsNullOrEmpty(InputUtilisateur.Text))
                {
                    _enchere.UtilisateurEnchere = UtilisateurORM.GetUtilisateurById(InputUtilisateur.Text);
                }

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
    }
}