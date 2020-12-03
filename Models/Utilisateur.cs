using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Utilisateur : Personne
    {
        private string _idUtilisateur;

        private bool _isSolvable;
        private bool _isRessortissant;
        private bool _identityExist;
        private List<string> _listeMotClef;

        
        public Utilisateur(string idUtilisateur, bool isSolvable, bool isRessortissant, bool identityExist,
            List<string> listeMotClef, string idPersonne, string nom, string prenom, DateTime age, string email, 
            string password, string telephoneMobile, string telephoneFixe)
        {
            this._idPersonne = idPersonne;
            this._nom = nom;
            this._prenom = prenom;
            this._age = age;
            this._email = email;
            this._password = password;
            this._telephoneMobile = telephoneMobile;
            this._telephoneFixe = telephoneFixe;
            this._idUtilisateur = idUtilisateur;
            this._isSolvable = isSolvable;
            this._isRessortissant = isRessortissant;
            this._identityExist = identityExist;
            this._listeMotClef = listeMotClef;
        }
    }
}