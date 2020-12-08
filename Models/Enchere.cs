using System;

namespace BidCardCoin.Models
{
    public class Enchere
    {
        private string _idEnchere;
        private double _prixProposer;
        private bool _isAdjuger;
        private DateTime _dateHeureVente;
        private OrdreAchat _ordreAchat;
        private Lot _lot;
        private Commissaire _commissaire;
        private Utilisateur _utilisateur;

        public Enchere(string idEnchere, double prixProposer, bool isAdjuger, DateTime dateHeureVente,
            OrdreAchat ordreAchat, Lot lot, Commissaire commissaire, Utilisateur utilisateur)
        {
            this._idEnchere = idEnchere;
            this._prixProposer = prixProposer;
            this._isAdjuger = isAdjuger;
            this._dateHeureVente = dateHeureVente;
            this._ordreAchat = ordreAchat;
            this._lot = lot;
            this._commissaire = commissaire;
            this._utilisateur = utilisateur;
        }
        
        public string IdEnchere
        {
            get => _idEnchere;
            set => _idEnchere = value;
        }

        public double PrixProposer
        {
            get => _prixProposer;
            set => _prixProposer = value;
        }

        public bool IsAdjuger
        {
            get => _isAdjuger;
            set => _isAdjuger = value;
        }

        public Lot Lot
        {
            get => _lot;
            set => _lot = value;
        }
    }
}