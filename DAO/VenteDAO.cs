using System;

namespace bidCardCoin.DAO
{
    public class VenteDAO
    {
        public VenteDAO()
        {
        }

        public VenteDAO(string idVente, string lotId, string adresseId, DateTime dateDebut)
        {
            IdVente = idVente;
            LotId = lotId;
            AdresseId = adresseId;
            DateDebut = dateDebut;
        }

        public string IdVente { get; }
        public string LotId { get; }
        public string AdresseId { get; }
        public DateTime DateDebut { get; }
    }
}