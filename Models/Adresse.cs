using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Adresse
    {
        private string _idAdresse;
        private string _pays;

        public string IdAdresse
        {
            get => _idAdresse;
            set => _idAdresse = value;
        }

        public string Pays
        {
            get => _pays;
            set => _pays = value;
        }

        public string Region
        {
            get => _region;
            set => _region = value;
        }

        public string Ville
        {
            get => _ville;
            set => _ville = value;
        }
        

        public string CodePostal
        {
            get => _codePostal;
            set => _codePostal = value;
        }

        public string AdresseNb
        {
            get => _adresse;
            set => _adresse = value;
        }

        public List<Utilisateur> Utilisateurs
        {
            get => _utilisateurs;
            set => _utilisateurs = value;
        }

        private string _region;
        private string _ville;
        private string _codePostal;
        private string _adresse;
        private List<Utilisateur> _utilisateurs;

        public Adresse(string idAdresse, string pays, string region, string ville, string codePostal, string adresse, List<Utilisateur> users)
        {
            this._idAdresse = idAdresse;
            this._pays = pays;
            this._region = region;
            this._ville = ville;
            this._codePostal = codePostal;
            this._adresse = adresse;
            this._utilisateurs = users;
        }
    }
}