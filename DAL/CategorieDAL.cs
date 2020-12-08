using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public class CategorieDAL
    {
        // SELECT

        static CategorieDAO SelectCategorieById(string id)
        {
            // Selectionné l'Categorie a partir de l'id
            return new CategorieDAO();
        }


        static List<CategorieDAO> SelectAllCategorie()
        {
            // Selectionné tout les Categorie dans la base de donnée
            return new List<CategorieDAO>();
        }


// INSERT

        static void InsertNewCategorie(CategorieDAO Categorie)
        {
            // Inserer Categorie dans la bdd
        }

// UPDATE

        static void UpdateCategorie(CategorieDAO Categorie)
        {
            // Mettre a jour Categorie dans la bdd
        }

// DELETE

        static void DeleteCategorie(string CategorieId)
        {
            // Supprimer Categorie dans la bdd
        }
    }
}
