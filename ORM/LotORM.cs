using System.Collections.Generic;
using bidCardCoin.DAL;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class LotORM
    {
        private static readonly Dictionary<string, Lot> _lotsDictionary = new Dictionary<string, Lot>();

        private static bool LotAlreadyInDictionary(string id)
        {
            return _lotsDictionary.ContainsKey(id);
        }
        // todo -> liens vers des : lots

        public static void Populate(List<Lot> lots)
        {
            // liste des ordreAchats qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var lot in lots)
            {
                if (!LotAlreadyInDictionary(lot.IdLot)) GetLotById(lot.IdLot);

                lot.IdLot = _lotsDictionary[lot.IdLot].IdLot;
                lot.Description = _lotsDictionary[lot.IdLot].Description;
                lot.NomLot = _lotsDictionary[lot.IdLot].NomLot;
                lot.ListeProduit = _lotsDictionary[lot.IdLot].ListeProduit;
            }
        }

        public static void Populate(Lot lot)
        {
            // liste des ordreAchats qui on beusoin de se faire peupler (leurs liste utilisateurs)


            if (!LotAlreadyInDictionary(lot.IdLot)) GetLotById(lot.IdLot);

            lot.IdLot = _lotsDictionary[lot.IdLot].IdLot;
            lot.Description = _lotsDictionary[lot.IdLot].Description;
            lot.NomLot = _lotsDictionary[lot.IdLot].NomLot;
            lot.ListeProduit = _lotsDictionary[lot.IdLot].ListeProduit;
        }

        public static Lot GetLotById(string id, bool initializer = true)
        {
            var lot = new Lot();

            var ldao = LotDAL.SelectLotById(id);
            var lproduit = new List<Produit>();

            if (initializer)
            {
                var produits = ProduitORM.GetAllProduit();
                foreach (var produit in produits)
                    if (produit.LotProduit.IdLot == id)
                        lproduit.Add(produit);
            }

            lot = new Lot(id, ldao.NomLot, ldao.Description, lproduit);

            if (initializer)
            {
                _lotsDictionary[lot.IdLot] = lot;
                ProduitORM.Populate(lproduit);
            }

            return lot;
        }

        public static List<Lot> GetAllLots()
        {
            var lldao = LotDAL.SelectAllLot();
            var lots = new List<Lot>();

            foreach (var ldao in lldao) lots.Add(GetLotById(ldao.IdLot));

            return lots;
        }
    }
}