using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using bidCardCoin.DAL;
using BidCardCoin.Models;
using bidCardCoin.ORM;

namespace BidCardCoin.Vue.CRUD
{
    public partial class AddUtilisateurView : UserControl
    {
        private Utilisateur _user;

        public AddUtilisateurView(Utilisateur user = null)
        {
            _user = user;
            InitializeComponent();


    

            _user = user ??  new Utilisateur();
            
        }


        private void CreateNewUtilisateur(object sender, RoutedEventArgs e)
        {
            var uuid = Guid.NewGuid().ToString();
            var idPersonne = Guid.NewGuid().ToString();
            List<string> listeMotClef = new List<string>(new[] {"carte", "pokemon"});
            List<Adresse> listeAdresses = new List<Adresse>();
            
            _user.IdUtilisateur = uuid;
            _user.IdPersonne = idPersonne;
            _user.Nom = InputNom.Text;
            _user.Prenom = InputPrenom.Text;
            _user.Age = int.TryParse(InputAge.Text,out _)?int.Parse(InputAge.Text):20;
            _user.Email = InputEmail.Text;
            _user.Password = InputPassword.Password;
            _user.IdentityExist = InputIdentity.IsChecked ?? false;
            _user.IsSolvable = InputSolvable.IsChecked ?? false;
            _user.IsRessortissant = InputRessortissant.IsChecked ?? false;
            _user.TelephoneFixe = InputFixe.Text;
            _user.TelephoneMobile = InputMobile.Text;
             _user.ListeMotClef = listeMotClef;
             _user.Adresses = listeAdresses;


             UtilisateurORM.AddUtilisateur(_user);
            
        }
    }
}