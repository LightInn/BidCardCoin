using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class VenteORM
    {
        private static Dictionary<string, Vente> _ventesDictionary = new Dictionary<string, Vente>();

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
                if (!VenteAlreadyInDictionary(vente.IdVente))
                {
                    GetVenteById(vente.IdVente);
                }

                vente.LotVente = _ventesDictionary[vente.IdVente].LotVente;
                vente.AdresseVente = _ventesDictionary[vente.IdVente].AdresseVente;
            }
        }

        public static void Populate(Vente vente)
        {
            // liste des ventes qui on beusoin de se faire peupler (leurs liste utilisateurs)

            if (!VenteAlreadyInDictionary(vente.IdVente))
            {
                GetVenteById(vente.IdVente);
            }

            vente.LotVente = _ventesDictionary[vente.IdVente].LotVente;
            vente.AdresseVente = _ventesDictionary[vente.IdVente].AdresseVente;
        }

        public static Vente GetVenteById(string id, bool initializer = true)
        {
            VenteDAO vdao = VenteDAL.SelectVenteById(id);
            Lot lotVente = new Lot();
            Adresse adresseVente = new Adresse();

            if (initializer)
            {
                lotVente = LotORM.GetLotById(LotDAL.SelectLotById(vdao.LotId).IdLot, false);
                adresseVente = AdresseORM.GetAdresseById(AdresseDAL.SelectAdresseById(vdao.AdresseId).IdAdresse, false);
            }


            Vente vente = new Vente(vdao.IdVente, vdao.DateDebut, adresseVente, lotVente);

            if (initializer)
            {
                _ventesDictionary[vente.IdVente] = vente;
                LotORM.Populate(vente.LotVente);
                AdresseORM.Populate(vente.AdresseVente);
            }

            return vente;
        }
        
        public static List<Vente> GetAllVente()
        {
            List<VenteDAO> lvdao = VenteDAL.SelectAllVente();
            List<Vente> ventes = new List<Vente>();

            foreach (var vdao in lvdao)
            {
                ventes.Add(GetVenteById(vdao.IdVente));
            }

            return ventes;
        }
    }
}