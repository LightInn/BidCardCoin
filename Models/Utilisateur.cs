using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Utilisateur : Personne
    {
        private string _idUtilisateur;

        public string IdUtilisateur
        {
            get => _idUtilisateur;
            set => _idUtilisateur = value;
        }

        public bool IsSolvable
        {
            get => _isSolvable;
            set => _isSolvable = value;
        }

        public bool IsRessortissant
        {
            get => _isRessortissant;
            set => _isRessortissant = value;
        }

        public bool IdentityExist
        {
            get => _identityExist;
            set => _identityExist = value;
        }

        public List<string> ListeMotClef
        {
            get => _listeMotClef;
            set => _listeMotClef = value;
        }

        public string IdPersonne
        {
            get => _idPersonne;
            set => _idPersonne = value;
        }

        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }

        public string Prenom
        {
            get => _prenom;
            set => _prenom = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string TelephoneMobile
        {
            get => _telephoneMobile;
            set => _telephoneMobile = value;
        }

        public string TelephoneFixe
        {
            get => _telephoneFixe;
            set => _telephoneFixe = value;
        }

        public List<Adresse> Adresses
        {
            get => _adresses;
            set => _adresses = value;
        }

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

        public Utilisateur()
        {
            
        }
    }
}