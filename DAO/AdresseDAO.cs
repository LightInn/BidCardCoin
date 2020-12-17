using System.Collections.Generic;

namespace bidCardCoin.DAO
{
    public class AdresseDAO
    {
        public AdresseDAO()
        {
        }

        public AdresseDAO(string idAdresse, string pays, string region, string ville, string codePostal, string adresse,
            List<string> listePersonneId)
        {
            IdAdresse = idAdresse;
            Pays = pays;
            Region = region;
            Ville = ville;
            CodePostal = codePostal;
            Adresse = adresse;
            ListePersonneId = listePersonneId;
        }

        public string IdAdresse { get; }
        public string Pays { get; }
        public string Region { get; }
        public string Ville { get; }
        public string CodePostal { get; }
        public string Adresse { get; }
        public List<string> ListePersonneId { get; set; }
    }
}