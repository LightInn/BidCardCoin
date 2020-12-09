using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class PersonneDAO
    {
        private string _idPersonne;
        private string _nom;
        private string _prenom;
        private int _age;
        private string _email;
        private string _password;
        private string _telephoneMobile;
        private string _telephoneFixe;
        private List<string> _adresses;

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

        public List<string> Adresses
        {
            get => _adresses;
            set => _adresses = value;
        }


        public PersonneDAO()
        {
        }

        public PersonneDAO(string idPersonne, string nom, string prenom, int age, string email, string password,
            string telephoneMobile, string telephoneFixe, List<string> adresses)
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
        }
    }
}