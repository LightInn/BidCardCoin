using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class OrdreAchatDAO
    {
        public string IdOrdreAchat { get; }
        public string UtilisateurId { get; }
        public string LotId { get; }
        public bool Informatiser { get; }
        public double MontantMax { get; }
        public DateTime Date { get; }

        public OrdreAchatDAO()
        {
        }

        public OrdreAchatDAO(string idOrdreAchat, string utilisateurId, string lotId, bool informatiser, double montantMax, DateTime date)
        {
            this.IdOrdreAchat = idOrdreAchat;
            this.UtilisateurId = utilisateurId;
            this.LotId = lotId;
            this.Informatiser = informatiser;
            this.MontantMax = montantMax;
            this.Date = date;
        }
    }
}
