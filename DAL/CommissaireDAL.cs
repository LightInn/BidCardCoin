using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class CommissaireDAL
    {
        // SELECT

        public static CommissaireDAO SelectCommissaireById(string id)
        {
            // Selectionné l'Commissaire a partir de l'id
            return new CommissaireDAO();
        }


        public static List<CommissaireDAO> SelectAllCommissaire()
        {
            // Selectionné tout les Commissaire dans la base de donnée
            return new List<CommissaireDAO>();
        }


// INSERT

        public static void InsertNewCommissaire(CommissaireDAO Commissaire)
        {
            // Inserer Commissaire dans la bdd


            //     INSERT INTO public.commissaire (
            //     "idCommissaire", "personneId"
            // ) VALUES (
            //     '33520d82-39f6-11eb-adc1-0242ac120002', 'c7f07ec8-39f2-11eb-adc1-0242ac120002')
            // returning "idCommissaire";

        }

// UPDATE

        public static void UpdateCommissaire(CommissaireDAO Commissaire)
        {
            // Mettre a jour Commissaire dans la bdd
        }

// DELETE

        public static void DeleteCommissaire(string CommissaireId)
        {
            // Supprimer Commissaire dans la bdd
        }
    }
}
