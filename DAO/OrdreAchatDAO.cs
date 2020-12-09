using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class OrdreAchatDAO
    {
        private string _idOrdreAchat;
        private string _utilisateurId;
        private string _lotId;
        private bool _informatiser;
        private double _montantMax;
        // todo DateTime ou string ? objet dans dao ou on vise la transformation en objet pour orm ?
        // private DateTime date;
        private string _date;

        public OrdreAchatDAO()
        {
        }

        public OrdreAchatDAO(string idOrdreAchat, string utilisateurId, string lotId, bool informatiser, double montantMax, string date)
        {
            this._idOrdreAchat = idOrdreAchat;
            this._utilisateurId = utilisateurId;
            this._lotId = lotId;
            this._informatiser = informatiser;
            this._montantMax = montantMax;
            this._date = date;
        }
    }
}
