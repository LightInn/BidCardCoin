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
    public class OrdreAchatORM
    {
        private static Dictionary<string, OrdreAchat> _ordreAchatsDictionary = new Dictionary<string, OrdreAchat>();

        private static bool OrdreAchatAlreadyInDictionary(string id)
        {
            return _ordreAchatsDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Utilisateur / Lot

        public static void Populate(List<OrdreAchat> ordreAchats)
        {
            // liste des ordreAchats qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var ordreAchat in ordreAchats)
            {
                if (!OrdreAchatAlreadyInDictionary(ordreAchat.IdOrdreAchat))
                {
                    GetOrdreAchatById(ordreAchat.IdOrdreAchat);
                }

                ordreAchat.UtilisateurOrdreAchat =
                    _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].UtilisateurOrdreAchat;
                ordreAchat.LotOrdreAchat = _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].LotOrdreAchat;
            }
        }

        public static void Populate(OrdreAchat ordreAchat)
        {
            // liste des ordreAchats qui on beusoin de se faire peupler (leurs liste utilisateurs)


            if (!OrdreAchatAlreadyInDictionary(ordreAchat.IdOrdreAchat))
            {
                GetOrdreAchatById(ordreAchat.IdOrdreAchat);
            }

            ordreAchat.UtilisateurOrdreAchat = _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].UtilisateurOrdreAchat;
            ordreAchat.LotOrdreAchat = _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].LotOrdreAchat;
        }

        public static OrdreAchat GetOrdreAchatById(string id, bool initializer = true)
        {
            OrdreAchat ordreAchat = new OrdreAchat();
            OrdreAchatDAO odao = OrdreAchatDAL.SelectOrdreAchatById(id);
            Lot lotOrdreAchat = new Lot();
            Utilisateur utilisateurOrdreAchat = new Utilisateur();


            if (initializer)
            {
                utilisateurOrdreAchat =
                    UtilisateurORM.GetUtilisateurById(
                        UtilisateurDAL.SelectUtilisateurById(odao.UtilisateurId).IdUtilisateur, false);
                lotOrdreAchat = LotORM.GetLotById(LotDAL.SelectLotById(odao.LotId).IdLot, false);
            }
            
            ordreAchat = new OrdreAchat(id,utilisateurOrdreAchat,lotOrdreAchat,odao.Informatiser,odao.MontantMax,odao.Date);
            
            if (initializer)
            {
                _ordreAchatsDictionary[ordreAchat.IdOrdreAchat] = ordreAchat;

                UtilisateurORM.Populate(new List<Utilisateur>(new []
                {
                    ordreAchat.UtilisateurOrdreAchat
                }));
                LotORM.Populate(ordreAchat.LotOrdreAchat);
            }

            return ordreAchat;
        }
        
        public static List<OrdreAchat> GetAllOrdreAchat()
        {
            List<OrdreAchatDAO> lodao = OrdreAchatDAL.SelectAllOrdreAchat();
            List<OrdreAchat> ordreAchats = new List<OrdreAchat>();

            foreach (var odao in lodao)
            {
                ordreAchats.Add(GetOrdreAchatById(odao.IdOrdreAchat));
            }

            return ordreAchats;
        }
    }
}