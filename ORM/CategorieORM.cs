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
        /* beuuuurk
        public static Categorie verifPresenceCategorie(CategorieDAO categorieDAO)
        {
            Categorie categorie= new Categorie();
            if (!Categorie.CategoriesCollection.ContainsKey(categorieDAO.IdCategorie))
            {
                Categorie.CategoriesCollection.Add(categorieDAO.IdCategorie,categorie);
            }
            else
            {
                categorie = Categorie.CategoriesCollection[categorieDAO.IdCategorie];
            }

            return categorie;
        }
        public static Categorie SelectCategorieById(string id)
        {
            CategorieDAO categorieDAO = CategorieDAL.SelectCategorieById(id);
            Categorie categorie = verifPresenceCategorie(categorieDAO);
            // Si categorie est null, c'est qu'elle éxistait pas dans la liste
            // on doit donc la remplir
            if (categorie.IdCategorie == null)
            {
                categorie.IdCategorie = categorieDAO.IdCategorie;
                if (categorieDAO.CategorieId != null)
                {
                    // todo eeeeeeet c'est un abandon de la part du joueur franco-malgache
                    //categorie.CategorieParent = categorieDAO.IdCategorie;
                }
                
                categorie.NomCategorie = categorieDAO.IdCategorie;
            }
        }
        */
    }
}
