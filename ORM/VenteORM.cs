using System.Collections.Generic;
using bidCardCoin.DAL;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class VenteORM
    {
        private static readonly Dictionary<string, Vente> _ventesDictionary = new Dictionary<string, Vente>();

        private static bool VenteAlreadyInDictionary(string id)
        {
            return _ventesDictionary.ContainsKey(id);
        }
        // todo -> liens vers des : Lot 
        // todo -> liens vers une : vente 

        public static void Populate(List<Vente> ventes)
        {
            // liste des ventes qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var vente in ventes)
            {
                if (!VenteAlreadyInDictionary(vente.IdVente)) GetVenteById(vente.IdVente);

                vente.LotVente = _ventesDictionary[vente.IdVente].LotVente;
                vente.AdresseVente = _ventesDictionary[vente.IdVente].AdresseVente;
            }
        }

        public static void Populate(Vente vente)
        {
            // liste des ventes qui on beusoin de se faire peupler (leurs liste utilisateurs)

            if (!VenteAlreadyInDictionary(vente.IdVente)) GetVenteById(vente.IdVente);

            vente.LotVente = _ventesDictionary[vente.IdVente].LotVente;
            vente.AdresseVente = _ventesDictionary[vente.IdVente].AdresseVente;
        }

        public static Vente GetVenteById(string id, bool initializer = true)
        {
            var vdao = VenteDAL.SelectVenteById(id);
            var lotVente = new Lot();
            var adresseVente = new Adresse();

            if (initializer)
            {
                lotVente = LotORM.GetLotById(LotDAL.SelectLotById(vdao.LotId).IdLot, false);
                adresseVente = AdresseORM.GetAdresseById(AdresseDAL.SelectAdresseById(vdao.AdresseId).IdAdresse, false);
            }


            var vente = new Vente(vdao.IdVente, vdao.DateDebut, adresseVente, lotVente);

            if (initializer)
            {
                _ventesDictionary[vente.IdVente] = vente;
                LotORM.Populate(vente.LotVente);
                AdresseORM.Populate(new List<Adresse>(new[] {vente.AdresseVente}));
            }

            return vente;
        }

        public static List<Vente> GetAllVente()
        {
            var lvdao = VenteDAL.SelectAllVente();
            var ventes = new List<Vente>();

            foreach (var vdao in lvdao) ventes.Add(GetVenteById(vdao.IdVente));

            return ventes;
        }
    }
}