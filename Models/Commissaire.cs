using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Commissaire : Personne
    {
        public string IdCommissaire { get; set; }

        // Todo version avec param optionnel 
        public Commissaire()
        {
        }
        public Commissaire(string idCommissaire, Personne personne, string idPersonne, string nom, string prenom,
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