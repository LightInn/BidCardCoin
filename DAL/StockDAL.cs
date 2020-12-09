using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class StockDAL
    {
        // SELECT

        public static StockDAO SelectStockById(string id)

        {
            // Selectionné l'Stock a partir de l'id
            return new StockDAO();
        }


        public static List<StockDAO> SelectAllStock()
        {
            // Selectionné tout les Stock dans la base de donnée
            return new List<StockDAO>();
        }


// INSERT

        public static void InsertNewStock(StockDAO Stock)
        {
            // Inserer Stock dans la bdd
        }

// UPDATE

        public static void UpdateStock(StockDAO Stock)
        {
            // Mettre a jour Stock dans la bdd
        }

// DELETE

        public static void DeleteStock(string StockId)
        {
            // Supprimer Stock dans la bdd
        }
            
    }
}
