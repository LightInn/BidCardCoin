using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class UtilisateurDAO
    {
        private string _idUtilisateur;

        public string IdUtilisateur
        {
            get => _idUtilisateur;
            set => _idUtilisateur = value;
        }

        public string PersonneId
        {
            get => _personneId;
            set => _personneId = value;
        }

        public bool VerifSolvable
        {
            get => _verifSolvable;
            set => _verifSolvable = value;
        }

        public bool VerifRessortissant
        {
            get => _verifRessortissant;
            set => _verifRessortissant = value;
        }

        public bool VerifIdentite
        {
            get => _verifIdentite;
            set => _verifIdentite = value;
        }

        public List<string> ListeMotClef
        {
            get => _listeMotClef;
            set => _listeMotClef = value;
        }

        private string _personneId;
        private bool _verifSolvable;
        private bool _verifRessortissant;
        private bool _verifIdentite;
        private List<string> _listeMotClef;

        // étranger

        public UtilisateurDAO()
        {
        }

        public UtilisateurDAO(string idUtilisateur, string personneId, bool verifSolvable, bool verifRessortissant,
            bool verifIdentite, List<string> listeMotClef)
        {
            this._idUtilisateur = idUtilisateur;
            this._personneId = personneId;
            this._verifSolvable = verifSolvable;
            this._verifRessortissant = verifRessortissant;
            this._verifIdentite = verifIdentite;
            this._listeMotClef = listeMotClef;
        }
    }
}