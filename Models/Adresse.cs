using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Adresse
    {
        public string IdAdresse { get; }
        public string Pays { get; }
        public string Region { get; }
        public string Ville { get; }
        public string CodePostal { get; }
        public string AdresseNom { get; }
        public List<Personne> ListePersone { get; }

        public Adresse(string idAdresse, string pays, string region, string ville, string codePostal, string adresse, List<Personne> listePersone)
        {
            this.IdAdresse = idAdresse;
            this.Pays = pays;
            this.Region = region;
            this.Ville = ville;
            this.CodePostal = codePostal;
            this.AdresseNom = adresse;
            this.ListePersone = listePersone;
        }
    }
}