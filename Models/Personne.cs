using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public abstract class Personne
    {
        protected List<Adresse> _adresses;
        protected int _age;
        protected string _email;
        protected string _idPersonne;
        protected string _nom;
        protected string _password;
        protected string _prenom;
        protected string _telephoneFixe;
        protected string _telephoneMobile;
    }
}