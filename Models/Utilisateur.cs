using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using bidCardCoin.ORM;

namespace BidCardCoin.Models
{
    public class Utilisateur : Personne, INotifyPropertyChanged
    {
        private string _idUtilisateur;

        public string IdUtilisateur
        {
            get => _idUtilisateur;
            set
            {
                _idUtilisateur = value;
                OnPropertyChanged("IdUtilisateur");
            }
        }

        public bool IsSolvable
        {
            get => _isSolvable;
            set
            {
                _isSolvable = value;
                OnPropertyChanged("IsSolvable");
            }
        }

        public bool IsRessortissant
        {
            get => _isRessortissant;
            set
            {
                _isRessortissant = value;
                OnPropertyChanged("IsRessortissant");
            }
        }

        public bool IdentityExist
        {
            get => _identityExist;
            set
            {
                _identityExist = value;
                OnPropertyChanged("IdentityExist");
            }
        }

        public List<string> ListeMotClef
        {
            get => _listeMotClef;
            set
            {
                _listeMotClef = value;
                OnPropertyChanged("ListeMotClef");
            }
        }

        public string IdPersonne
        {
            get => _idPersonne;
            set
            {
                _idPersonne = value;
                OnPropertyChanged("IdPersonne");
            }
        }

        public string Nom
        {
            get => _nom;
            set
            {
                _nom = value;
                OnPropertyChanged("Nom");
            }
        }

        public string Prenom
        {
            get => _prenom;
            set
            {
                _prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string TelephoneMobile
        {
            get => _telephoneMobile;
            set
            {
                _telephoneMobile = value;
                OnPropertyChanged("TelephoneMobile");
            }
        }

        public string TelephoneFixe
        {
            get => _telephoneFixe;
            set
            {
                _telephoneFixe = value;
                OnPropertyChanged("TelephoneFixe");
            }
        }

        public List<Adresse> Adresses
        {
            get => _adresses;
            set
            {
                _adresses = value;
                OnPropertyChanged("Adresses");
            }
        }

        private bool _isSolvable;
        private bool _isRessortissant;
        private bool _identityExist;
        private List<string> _listeMotClef;


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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
                UtilisateurORM.UpdateUtilisateur(this);
            }
        }
    }
}