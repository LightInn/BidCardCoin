using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Utilisateur
    {
        private string _idUtilisateur;

        private Personne _personne;
        private bool _isSolbable;
        private bool _isResotissant;
        private bool _identityExist;
        private List<string> _listeMotClef;

        public Utilisateur(string idUtilisateur, bool isSolbable, bool isResotissant, bool identityExist,
            List<string> listeMotClef, Personne personne)
        {
            this._idUtilisateur = idUtilisateur;
            this._isSolbable = isSolbable;
            this._isResotissant = isResotissant;
            this._identityExist = identityExist;
            this._listeMotClef = listeMotClef;
            _personne = personne;
        }
    }
}