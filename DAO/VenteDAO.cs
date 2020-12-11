using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class VenteDAO
    {
        public string IdVente { get; }
        public string LotId { get; }
        public string AdresseId { get; }
        public DateTime DateDebut { get; }

        public VenteDAO()
        {
        }

        public VenteDAO(string idVente, string lotId, string adresseId, DateTime dateDebut)
        {
            this.IdVente = idVente;
            this.LotId = lotId;
            this.AdresseId = adresseId;
            this.DateDebut = dateDebut;
        }
    }
}
