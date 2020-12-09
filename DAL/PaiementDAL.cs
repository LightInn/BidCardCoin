using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static  class PaiementDAL
    {
        // SELECT


        public static PaiementDAO SelectPaiementById(string id)

        {
            // Selectionné l'Paiement a partir de l'id
            return new PaiementDAO();
        }


        public static List<PaiementDAO> SelectAllPaiement()
        {
            // Selectionné tout les Paiement dans la base de donnée
            return new List<PaiementDAO>();
        }


// INSERT

        public static void InsertNewPaiement(PaiementDAO Paiement)
        {
            // Inserer Paiement dans la bdd
        }

// UPDATE

        public static void UpdatePaiement(PaiementDAO Paiement)
        {
            // Mettre a jour Paiement dans la bdd
        }

// DELETE

        public static void DeletePaiement(string PaiementId)
        {
            // Supprimer Paiement dans la bdd
        }
    
    }
}
