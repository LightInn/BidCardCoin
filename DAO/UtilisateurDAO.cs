using System.Collections.Generic;

namespace bidCardCoin.DAO
{
    public class UtilisateurDAO
    {
        // étranger

        public UtilisateurDAO()
        {
        }

        public UtilisateurDAO(string idUtilisateur, string personneId, bool verifSolvable, bool verifRessortissant,
            bool verifIdentite, List<string> listeMotClef)
        {
            IdUtilisateur = idUtilisateur;
            PersonneId = personneId;
            VerifSolvable = verifSolvable;
            VerifRessortissant = verifRessortissant;
            VerifIdentite = verifIdentite;
            ListeMotClef = listeMotClef;
        }

        public string IdUtilisateur { get; set; }

        public string PersonneId { get; set; }

        public bool VerifSolvable { get; set; }

        public bool VerifRessortissant { get; set; }

        public bool VerifIdentite { get; set; }

        public List<string> ListeMotClef { get; set; }
    }
}