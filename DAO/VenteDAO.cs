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
        public string ProduitId { get; }
        public string AdresseId { get; }
        public DateTime DateDebut { get; }

        public VenteDAO()
        {
        }

        public VenteDAO(string idVente, string produitId, string adresseId, DateTime dateDebut)
        {
            this.IdVente = idVente;
            this.ProduitId = produitId;
            this.AdresseId = adresseId;
            this.DateDebut = dateDebut;
        }
    }
}
