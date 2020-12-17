using System.Collections.Generic;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class EnchereORM
    {
        private static readonly Dictionary<string, Enchere> _encheresDictionary = new Dictionary<string, Enchere>();

        private static bool EnchereAlreadyInDictionary(string id)
        {
            if (!string.IsNullOrEmpty(id)) return _encheresDictionary.ContainsKey(id);

            return false;
        }

        // todo -> liens vers un : Commissaire // Lot // Ordre OrdreAchatEnchere OU Utilisateur
        public static void Populate(List<Enchere> encheres)
        {
            // liste des encheres qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var enchere in encheres)
            {
                if (!EnchereAlreadyInDictionary(enchere.IdEnchere)) GetEnchereById(enchere.IdEnchere);

                enchere.CommissaireEnchere = _encheresDictionary[enchere.IdEnchere].CommissaireEnchere;
                enchere.LotEnchere = _encheresDictionary[enchere.IdEnchere].LotEnchere;
                enchere.OrdreAchatEnchere = _encheresDictionary[enchere.IdEnchere].OrdreAchatEnchere;
                enchere.UtilisateurEnchere = _encheresDictionary[enchere.IdEnchere].UtilisateurEnchere;
            }
        }

        public static void Populate(Enchere enchere)
        {
            // liste des encheres qui on beusoin de se faire peupler (leurs liste utilisateurs)

            if (!EnchereAlreadyInDictionary(enchere.IdEnchere)) GetEnchereById(enchere.IdEnchere);

            enchere.CommissaireEnchere = _encheresDictionary[enchere.IdEnchere].CommissaireEnchere;
            enchere.LotEnchere = _encheresDictionary[enchere.IdEnchere].LotEnchere;
            enchere.OrdreAchatEnchere = _encheresDictionary[enchere.IdEnchere].OrdreAchatEnchere;
            enchere.UtilisateurEnchere = _encheresDictionary[enchere.IdEnchere].UtilisateurEnchere;
        }

        public static Enchere GetEnchereById(string id, bool initializer = true)
        {
            var edao = EnchereDAL.SelectEnchereById(id);
            var commissaireEnchere = new Commissaire();
            var lotEnchere = new Lot();
            var ordreAchatEnchere = new OrdreAchat();
            var utilisateurEnchere = new Utilisateur();


            if (initializer)
            {
                commissaireEnchere =
                    CommissaireORM.GetCommissaireById(edao.CommissaireId, false);
                lotEnchere = LotORM.GetLotById(edao.LotId, false);
                if (edao.OrdreAchatId != null)
                    ordreAchatEnchere =
                        OrdreAchatORM.GetOrdreAchatById(edao.OrdreAchatId, false);

                if (edao.UtilisateurId != null)
                    utilisateurEnchere =
                        UtilisateurORM.GetUtilisateurById(edao.UtilisateurId, false);
            }

            var enchere = new Enchere(edao.IdEnchere, edao.PrixProposer, edao.EstAdjuger, edao.DateHeureVente,
                ordreAchatEnchere, lotEnchere, commissaireEnchere, utilisateurEnchere);

            if (initializer)
            {
                _encheresDictionary[enchere.IdEnchere] = enchere;

                CommissaireORM.Populate(new List<Commissaire>(new[]
                {
                    enchere.CommissaireEnchere
                }));
                LotORM.Populate(enchere.LotEnchere);
                if (edao.OrdreAchatId != null) OrdreAchatORM.Populate(enchere.OrdreAchatEnchere);

                if (edao.UtilisateurId != null)
                    UtilisateurORM.Populate(new List<Utilisateur>(new[]
                    {
                        enchere.UtilisateurEnchere
                    }));
            }

            return enchere;
        }

        public static List<Enchere> GetAllEnchere()
        {
            var ledao = EnchereDAL.SelectAllEnchere();
            var encheres = new List<Enchere>();

            foreach (var edao in ledao)
                if (!string.IsNullOrEmpty(edao.IdEnchere))
                    encheres.Add(GetEnchereById(edao.IdEnchere));

            return encheres;
        }

        public static EnchereDAO EnchereToEnchereDAO(Enchere enchere)
        {
            string utilisateurid;
            string ordreachatid;
            if (enchere.OrdreAchatEnchere == null)
                ordreachatid = null;
            else
                ordreachatid = enchere.OrdreAchatEnchere.IdOrdreAchat;

            if (enchere.UtilisateurEnchere == null)
                utilisateurid = null;
            else
                utilisateurid = enchere.UtilisateurEnchere.IdUtilisateur;

            return new EnchereDAO(enchere.IdEnchere, enchere.PrixProposer, enchere.IsAdjuger, enchere.DateHeureVente,
                enchere.LotEnchere.IdLot, enchere.CommissaireEnchere.IdCommissaire,
                ordreachatid, utilisateurid);
        }

        public static void InsertOrAddNewEnchere(Enchere enchere)
        {
            EnchereDAL.InsertNewEnchere(EnchereToEnchereDAO(enchere));
        }


        public static void UpadateEnchere(Enchere enchere)
        {
            EnchereDAL.UpdateEnchere(EnchereToEnchereDAO(enchere));
        }


        public static void DeleteEnchere(Enchere enchere)
        {
            EnchereDAL.DeleteEnchere(enchere.IdEnchere);
        }
    }
}