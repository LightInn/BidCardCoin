using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Commissaire : Personne
    {
        public string IdCommissaire { get; set; }
        
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
        
        // Todo version avec param optionnel 
        public Commissaire()
        {
            
        }
        
        public Commissaire(string idCommissaire, string idPersonne, string nom, string prenom,
            int age, string email, string password, string telephoneMobile, string telephoneFixe, List<Adresse> adresses)
        {
            IdCommissaire = idCommissaire;
            _idPersonne = idPersonne;
            _nom = nom;
            _prenom = prenom;
            _age = age;
            _email = email;
            _password = password;
            _telephoneMobile = telephoneMobile;
            _telephoneFixe = telephoneFixe;
            _adresses = adresses;
        }
    }
}