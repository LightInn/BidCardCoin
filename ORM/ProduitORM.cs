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
    public class ProduitORM
    {
        private static Dictionary<string, Produit> _produitsDictionary = new Dictionary<string, Produit>();

        private static bool ProduitAlreadyInDictionary(string id)
        {
            return _produitsDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Lot // Utilisateur // Stock // Enchere

        public static void Populate(List<Produit> produits)
        {
            // liste des produits qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var produit in produits)
            {
                if (!ProduitAlreadyInDictionary(produit.IdProduit))
                {
                    GetProduitById(produit.IdProduit);
                }

                produit.LotProduit = _produitsDictionary[produit.IdProduit].LotProduit;
                produit.UtilisateurProduit = _produitsDictionary[produit.IdProduit].UtilisateurProduit;
                produit.StockProduit = _produitsDictionary[produit.IdProduit].StockProduit;
                produit.EnchereGagnante = _produitsDictionary[produit.IdProduit].EnchereGagnante;
                produit.CategorieProduit = _produitsDictionary[produit.IdProduit].CategorieProduit;
            }
        }

        public static void Populate(Produit produit)
        {
            // liste des produits qui on beusoin de se faire peupler (leurs liste utilisateurs)

            if (!ProduitAlreadyInDictionary(produit.IdProduit))
            {
                GetProduitById(produit.IdProduit);
            }

            produit.LotProduit = _produitsDictionary[produit.IdProduit].LotProduit;
            produit.UtilisateurProduit = _produitsDictionary[produit.IdProduit].UtilisateurProduit;
            produit.StockProduit = _produitsDictionary[produit.IdProduit].StockProduit;
            produit.EnchereGagnante = _produitsDictionary[produit.IdProduit].EnchereGagnante;
            produit.CategorieProduit = _produitsDictionary[produit.IdProduit].CategorieProduit;
        }

        public static Produit GetProduitById(string id, bool initializer = true)
        {
            ProduitDAO pdao = ProduitDAL.SelectProduitById(id);
            Lot lotProduit = new Lot();
            Utilisateur utilisateurProduit = new Utilisateur();
            Stock stockProduit = new Stock();
            Enchere enchereGagnante = new Enchere();
            Categorie categorieProduit = new Categorie();


            if (initializer)
            {
                lotProduit = LotORM.GetLotById(LotDAL.SelectLotById(pdao.LotId).IdLot, false);
                utilisateurProduit =
                    UtilisateurORM.GetUtilisateurById(
                        UtilisateurDAL.SelectUtilisateurById(pdao.UtilisateurId).IdUtilisateur, false);
                stockProduit = StockORM.GetStockById(StockDAL.SelectStockById(pdao.StockId).IdStock, false);
                enchereGagnante =
                    EnchereORM.GetEnchereById(EnchereDAL.SelectEnchereById(pdao.EnchereGagnanteId).IdEnchere, false);
                //todo decomente ici
                // categorieProduit =
                //     CategorieORM.GetCategorieById(CategorieDAL.SelectCategorieById(pdao.CategorieId).CategorieId,
                //         false);
            }


            Produit produit = new Produit(pdao.IdProduit, lotProduit, utilisateurProduit, stockProduit, enchereGagnante,
                categorieProduit
                , pdao.NomArtiste, pdao.NomStyle, pdao.NomProduit, pdao.PrixReserve, pdao.ReferenceCatalogue,
                pdao.DescriptionProduit, pdao.PhotoId, pdao.IsSend);

            if (initializer)
            {
                _produitsDictionary[produit.IdProduit] = produit;

                LotORM.Populate(produit.LotProduit);
                UtilisateurORM.Populate(new List<Utilisateur>(new []
                {
                    produit.UtilisateurProduit
                }));
                StockORM.Populate(produit.StockProduit);
                EnchereORM.Populate(produit.EnchereGagnante);
                //todo decomenter ici
                // CategorieORM.Populate(produit.CategorieProduit);
            }

            return produit;
        }
    }
}