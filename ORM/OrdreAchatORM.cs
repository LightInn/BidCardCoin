using System.Collections.Generic;
using bidCardCoin.DAL;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class OrdreAchatORM
    {
        private static readonly Dictionary<string, OrdreAchat> _ordreAchatsDictionary =
            new Dictionary<string, OrdreAchat>();

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
                if (!OrdreAchatAlreadyInDictionary(ordreAchat.IdOrdreAchat)) GetOrdreAchatById(ordreAchat.IdOrdreAchat);

                ordreAchat.UtilisateurOrdreAchat =
                    _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].UtilisateurOrdreAchat;
                ordreAchat.LotOrdreAchat = _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].LotOrdreAchat;
            }
        }

        public static void Populate(OrdreAchat ordreAchat)
        {
            // liste des ordreAchats qui on beusoin de se faire peupler (leurs liste utilisateurs)


            if (!OrdreAchatAlreadyInDictionary(ordreAchat.IdOrdreAchat)) GetOrdreAchatById(ordreAchat.IdOrdreAchat);

            ordreAchat.UtilisateurOrdreAchat = _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].UtilisateurOrdreAchat;
            ordreAchat.LotOrdreAchat = _ordreAchatsDictionary[ordreAchat.IdOrdreAchat].LotOrdreAchat;
        }

        public static OrdreAchat GetOrdreAchatById(string id, bool initializer = true)
        {
            var ordreAchat = new OrdreAchat();
            var odao = OrdreAchatDAL.SelectOrdreAchatById(id);
            var lotOrdreAchat = new Lot();
            var utilisateurOrdreAchat = new Utilisateur();


            if (initializer)
            {
                utilisateurOrdreAchat =
                    UtilisateurORM.GetUtilisateurById(odao.UtilisateurId, false);
                lotOrdreAchat = LotORM.GetLotById(odao.LotId, false);
            }

            ordreAchat = new OrdreAchat(id, utilisateurOrdreAchat, lotOrdreAchat, odao.Informatiser, odao.MontantMax,
                odao.Date);

            if (initializer)
            {
                _ordreAchatsDictionary[ordreAchat.IdOrdreAchat] = ordreAchat;

                UtilisateurORM.Populate(new List<Utilisateur>(new[]
                {
                    ordreAchat.UtilisateurOrdreAchat
                }));
                LotORM.Populate(ordreAchat.LotOrdreAchat);
            }

            return ordreAchat;
        }

        public static List<OrdreAchat> GetAllOrdreAchat()
        {
            var lodao = OrdreAchatDAL.SelectAllOrdreAchat();
            var ordreAchats = new List<OrdreAchat>();

            foreach (var odao in lodao) ordreAchats.Add(GetOrdreAchatById(odao.IdOrdreAchat));

            return ordreAchats;
        }
    }
}