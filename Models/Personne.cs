using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public abstract class Personne
    {
        protected string _idPersonne;
        protected string _nom;
        protected string _prenom;
        protected int _age;
        protected string _email;
        protected string _password;
        protected string _telephoneMobile;
        protected string _telephoneFixe;
        protected List<Adresse> _adresses;
    }
    
}