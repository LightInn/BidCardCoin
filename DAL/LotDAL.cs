using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class LotDAL
    {
        // SELECT

        public static LotDAO SelectLotById(string id)
        {
            // Selectionné l'Lot a partir de l'id
            return new LotDAO();
        }


        public static List<LotDAO> SelectAllLot()
        {
            // Selectionné tout les Lot dans la base de donnée
            return new List<LotDAO>();
        }


// INSERT

        public static void InsertNewLot(LotDAO Lot)
        {
            // Inserer Lot dans la bdd
        }

// UPDATE

        public static void UpdateLot(LotDAO Lot)
        {
            // Mettre a jour Lot dans la bdd
        }

// DELETE

        public static void DeleteLot(string LotId)
        {
            // Supprimer Lot dans la bdd
        }
    }
}
