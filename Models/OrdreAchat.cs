using System;

namespace BidCardCoin.Models
{
    public class OrdreAchat
    {
        private string _idOrdreAchat; 
        private Utilisateur _utilisateur;
        private Lot _lot;
        private bool _autobot;
        private double _montantMax;
        private DateTime _dateCreation;

        public OrdreAchat(string idOrdreAchat, Utilisateur utilisateur, bool autobot, double montantMax, DateTime dateCreation, Lot lot)
        {
            this._idOrdreAchat = idOrdreAchat;
            _utilisateur = utilisateur;
            this._autobot = autobot;
            this._montantMax = montantMax;
            this._dateCreation = dateCreation;
            _lot = lot;
        }
    }
}