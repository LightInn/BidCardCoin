using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class AdresseDAO
    {
        public string IdAdresse { get; }
        public string Pays { get; }
        public string Region { get; }
        public string Ville { get; }
        public string CodePostal { get; }
        public string Adresse { get; }

        public AdresseDAO()
        {
            
        }
        public AdresseDAO(string idAdresse, string pays, string region, string ville, string codePostal, string adresse)

        {
            this.IdAdresse = idAdresse;
            this.Pays = pays;
            this.Region = region;
            this.Ville = ville;
            this.CodePostal = codePostal;
            this.Adresse = adresse;
        }

    }
}
