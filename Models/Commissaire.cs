using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Commissaire : Personne
    {
        private string _idCommissaire;

        // Todo version avec param optionnel 
        public Commissaire(string idCommissaire, Personne personne, string idPersonne, string nom, string prenom,
            int age, string email, string password, string telephoneMobile, string telephoneFixe, List<Adresse> adresses)
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
            
            this._idCommissaire = idCommissaire;
        }
    }
}