using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static  class CategorieDAL
    {
        // SELECT

        public static CategorieDAO SelectCategorieById(string id)

        {
            // Selectionné l'Categorie a partir de l'id
            return new CategorieDAO();
        }


        public static List<CategorieDAO> SelectAllCategorie()
        {
            // Selectionné tout les Categorie dans la base de donnée
            return new List<CategorieDAO>();
        }


// INSERT

        public static void InsertNewCategorie(CategorieDAO Categorie)
        {
            // Inserer Categorie dans la bdd
        }

// UPDATE

        public static void UpdateCategorie(CategorieDAO Categorie)
        {
            // Mettre a jour Categorie dans la bdd
        }

// DELETE

        public static void DeleteCategorie(string CategorieId)
        {
            // Supprimer Categorie dans la bdd
        }
        
        
    }
}
