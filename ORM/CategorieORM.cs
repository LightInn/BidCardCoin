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
    public class CategorieORM
    {


        // private static readonly Dictionary<string, Categorie>
        //     CategoriesDictionary = new Dictionary<string, Categorie>();
        //
        // private static bool CategorieAlreadyInDictionary(string id)
        // {
        //     return CategoriesDictionary.ContainsKey(id);
        // }
        //
        //
        // public static void PopulateMtm(List<Categorie> categories)
        // {
        //     // liste des adresses qui on beusoin de se faire peupler (leurs liste utilisateurs)
        //
        //     foreach (var category in categories)
        //     {
        //         if (CategorieAlreadyInDictionary(category.IdCategorie))
        //         {
        //             category.Utilisateurs = CategoriesDictionary[category.IdCategorie].Utilisateurs;
        //         }
        //         else
        //         {
        //             GetCategorieById(category.IdCategorie);
        //
        //             category.Utilisateurs = CategoriesDictionary[category.IdCategorie].Utilisateurs;
        //         }
        //     }
        // }
        //
        //
        // public static Categorie GetCategorieById(string id, bool initializer = true)
        // {
        //     CategorieDAO cdao = CategorieDAL.SelectCategorieById(id);
        //     List<Produit> listeProduits = new List<Produit>();
        //
        //     if (initializer)
        //     {
        //         foreach (var produitId in cdao.ListeProduitId)
        //         {
        //             Produit produit =
        //                 ProduitORM.GetProduitById(PersonneDAL.getChildReference(produitId), false);
        //             listeProduits.Add(produit);
        //         }
        //     }
        //
        //
        //     Categorie categorie = new Categorie(cdao.IdCategorie, cdao., cdao.Region, cdao.Ville, cdao.CodePostal,
        //         cdao.Categorie, listeProduits);
        //
        //
        //     if (initializer)
        //     {
        //         CategoriesDictionary[adresse.IdCategorie] = adresse;
        //         UtilisateurORM.PopulateMtm(adresse.Utilisateurs);
        //     }
        //
        //     return adresse;
        // }
        //
        //
        // public static List<Categorie> GetAllCategorie()
        // {
        //     List<CategorieDAO> ladao = CategorieDAL.SelectAllCategorie();
        //     List<Categorie> adresses = new List<Categorie>();
        //
        //     foreach (var adao in ladao)
        //     {
        //         adresses.Add(GetCategorieById(adao.IdCategorie));
        //     }
        //
        //     return adresses;
        // }
        //
        // static CategorieDAO CategorieToDao(Categorie adresse)
        // {
        //     return new CategorieDAO(adresse.IdCategorie, adresse.Pays, adresse.Region, adresse.Ville,
        //         adresse.CodePostal,
        //         adresse.CategorieNb, adresse.Utilisateurs.Select(user => user.IdUtilisateur).ToList());
        // }
        //
        // static void AddCategorie(Categorie user)
        // {
        //     CategorieDAL.InsertOrAddNewCategorie(CategorieToDao(user));
        // }
        //
        // static void UpdateCategorie(Categorie user)
        // {
        //     CategorieDAL.InsertOrAddNewCategorie(CategorieToDao(user));
        // }
        //
        // static void DeleteCategorie(Categorie user)
        // {
        //     CategorieDAL.DeleteCategorie(user.IdCategorie);
        // }

        /* beuuuurk
        public static Categorie verifPresenceCategorie(CategorieDAO categorieDAO)

        private static Dictionary<string, Categorie> _categoriesDictionary = new Dictionary<string, Categorie>();
        private static bool CategorieAlreadyInDictionary(string id)

        {
            return _categoriesDictionary.ContainsKey(id);
        }
        // todo - bré est en train de le faire normalement
        public static void Populate(List<Categorie> categories)
        {
            // todo
        }
        public static void Populate(Categorie categories)
        {
            // todo
        }

        public static Categorie GetCategorieById(string id, bool initializer = true)
        {
            // todo
            Categorie categorie = new Categorie();

            return categorie;
        }*/
    }
}