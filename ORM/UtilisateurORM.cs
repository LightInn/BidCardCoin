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
    public static class UtilisateurORM
    {
      public  static Utilisateur getUtilisateurById(string id)
        {
            UtilisateurDAO udao = UtilisateurDAL.SelectUtilisateurById(id);
            PersonneDAO pdao = PersonneDAL.SelectPersonneById(udao.PersonneId);

            List<Adresse> listeAdresse = new List<Adresse>();


            foreach (var adresse_in_dao in pdao.Adresses)
            {
                Adresse adresse = AdresseORM.getUtilisateurById(adresse_in_dao);
                listeAdresse.Add(adresse);
            }

            Utilisateur user = new Utilisateur(udao.IdUtilisateur, udao.VerifSolvable, udao.VerifRessortissant,
                udao.VerifIdentite, udao.ListeMotClef, pdao.IdPersonne, pdao.Nom, pdao.Prenom, pdao.Age, pdao.Email,
                pdao.Password, pdao.TelephoneMobile, pdao.TelephoneFixe, listeAdresse);
            
            return user;
        }

        static List<Utilisateur> getAllUtilisateur()
        {
            return new List<Utilisateur>();
        }


        static void addUtilisateur(Utilisateur user)
        {
        }

        static void updateUtilisateur(Utilisateur user)
        {
        }

        static void deleteUtilisateur(Utilisateur user)
        {
        }
    }
}