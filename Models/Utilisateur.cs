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
        

        // Todo version avec param optionnel 
        public Utilisateur(string idUtilisateur, bool isSolvable, bool isRessortissant, bool identityExist,
            List<string> listeMotClef, string idPersonne, string nom, string prenom, int age, string email,
            string password, string telephoneMobile, string telephoneFixe, List<Adresse> adresses)
        {
            this._idPersonne = idPersonne;
            this._nom = nom;
            this._prenom = prenom;
            this._age = age;
            this._email = email;
            this._password = password;
            this._telephoneMobile = telephoneMobile;
            this._telephoneFixe = telephoneFixe;
            this._adresses = adresses;
            
            this._idUtilisateur = idUtilisateur;
            this._isSolvable = isSolvable;
            this._isRessortissant = isRessortissant;
            this._identityExist = identityExist;
            this._listeMotClef = listeMotClef;
        }
    }
}