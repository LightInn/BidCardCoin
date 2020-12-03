using System;

namespace BidCardCoin.Models
{
    public class Personne
    {
        private string _idPersonne;
        private string _nom;
        private string _prenom;
        private DateTime _age;
        private string _email;
        private string _password;
        private string _telephoneMobile;
        private string _telephoneFixe;

        public Personne(string idPersonne, string nom, string prenom, DateTime age, string email, string password, string telephoneMobile, string telephoneFixe)
        {
            this._idPersonne = idPersonne;
            this._nom = nom;
            this._prenom = prenom;
            this._age = age;
            this._email = email;
            this._password = password;
            this._telephoneMobile = telephoneMobile;
            this._telephoneFixe = telephoneFixe;
        }
        
        
        
        
        
        
        
    }
    
}