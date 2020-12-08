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
        private string _personneId;
        private bool _verifSolvable;
        private bool _verifRessortissant;
        private bool _verifIdentite;
        private string _listeMotClef;

        // étranger
        public UtilisateurDAO(string idUtilisateur, string personneId, bool verifSolvable, bool verifRessortissant, bool verifIdentite, string listeMotClef)
        {
            this._idUtilisateur = idUtilisateur;
            this._personneId = personneId;
            this._verifSolvable = verifSolvable;
            this._verifRessortissant = verifRessortissant;
            this._verifIdentite = verifIdentite;
            this._listeMotClef = listeMotClef;
        }
        // non etranger
        public UtilisateurDAO(string idUtilisateur, string personneId, bool verifSolvable, string listeMotClef)
        {
            this._idUtilisateur = idUtilisateur;
            this._personneId = personneId;
            this._verifSolvable = verifSolvable;
            this._listeMotClef = listeMotClef;
        }
    }
}
