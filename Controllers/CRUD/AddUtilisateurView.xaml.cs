using System;
using System.Collections.Generic;
using System.Windows.Controls;
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


            var uuid = Guid.NewGuid().ToString();
            var idPersonne = Guid.NewGuid().ToString();
            List<string> listeMotClef = new List<string>(new[] {"sextoy", "poupe"});
            List<Adresse> listeAdresses = new List<Adresse>();

            _user = user ?? new Utilisateur(uuid, true, true, true, listeMotClef, idPersonne, "Nigga", "Andyounet", 55,
                "email", "123456", "45", null, listeAdresses);
        }
    }
}