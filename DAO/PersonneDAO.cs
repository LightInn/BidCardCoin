using System.Collections.Generic;

namespace bidCardCoin.DAO
{
    public class PersonneDAO
    {
        public PersonneDAO()
        {
        }

        public PersonneDAO(string idPersonne, string nom, string prenom, int age, string email, string password,
            string telephoneMobile, string telephoneFixe, List<string> adresses)
        {
            IdPersonne = idPersonne;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Email = email;
            Password = password;
            TelephoneMobile = telephoneMobile;
            TelephoneFixe = telephoneFixe;
            Adresses = adresses;
        }

        public string ChildReference { get; set; }

        public string IdPersonne { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string TelephoneMobile { get; set; }

        public string TelephoneFixe { get; set; }

        public List<string> Adresses { get; set; }
    }
}