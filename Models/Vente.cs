using System;

namespace BidCardCoin.Models
{
    public class Vente
    {
        public Vente(string idVente, DateTime dateDebut, Adresse adresseVente, Lot lotVente)
        {
            IdVente = idVente;
            DateDebut = dateDebut;
            AdresseVente = adresseVente;
            LotVente = lotVente;
        }

        public string IdVente { get; }
        public DateTime DateDebut { get; }
        public Adresse AdresseVente { get; set; }
        public Lot LotVente { get; set; }
    }
}