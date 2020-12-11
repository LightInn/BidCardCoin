using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Vente
    {
        public string IdVente { get; }
        public DateTime DateDebut { get; }
        public Adresse AdresseVente { get; set; }
        public Lot LotVente { get; set; }

        public Vente(string idVente, DateTime dateDebut,Adresse adresseVente, Lot lotVente)
        {
            IdVente = idVente;
            DateDebut = dateDebut;
            AdresseVente = adresseVente;
            LotVente = lotVente;
        }
    }
}