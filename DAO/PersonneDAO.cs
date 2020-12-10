using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class PersonneDAO
    {
        public string IdPersonne { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public int Age { get; }
        public string Email { get; }
        public string Password { get; }
        public string TelephoneMobile { get; }
        public string TelephoneFixe { get; }

        public PersonneDAO()
        {
        }

        public PersonneDAO(string idPersonne, string nom, string prenom, int age, string email, string password, string telephoneMobile, string telephoneFixe)
        {
            this.IdPersonne = idPersonne;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Email = email;
            this.Password = password;
            this.TelephoneMobile = telephoneMobile;
            this.TelephoneFixe = telephoneFixe;
        }
    }
}
