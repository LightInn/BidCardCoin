using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class ProduitDAL
    {
        // SELECT


        public static ProduitDAO SelectProduitById(string id)

        {
            // Selectionné l'Produit a partir de l'id
            return new ProduitDAO();
        }


        public static List<ProduitDAO> SelectAllProduit()
        {
            // Selectionné tout les Produit dans la base de donnée
            return new List<ProduitDAO>();
        }


// INSERT

        public static void InsertNewProduit(ProduitDAO Produit)
        {
            // Inserer Produit dans la bdd
        }

// UPDATE

        public static void UpdateProduit(ProduitDAO Produit)
        {
            // Mettre a jour Produit dans la bdd
        }

// DELETE

        public static void DeleteProduit(string ProduitId)
        {
            // Supprimer Produit dans la bdd
        }
            
    }
}
