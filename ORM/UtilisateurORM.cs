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
        private static Dictionary<string, Utilisateur> _utilisateurDictionary = new Dictionary<string, Utilisateur>();

        private static bool UtilisateurAlreadyInDictionary(string id)
        {
            return _utilisateurDictionary.ContainsKey(id);
        }

        public static void populateMTM(List<Utilisateur> users)
        {
            // liste des utilisateurs qui on beusoin de se faire peupler (leurs liste adresses)

            foreach (var user in users)
            {
                if (UtilisateurAlreadyInDictionary(user.IdUtilisateur))
                {
                    user.Adresses = _utilisateurDictionary[user.IdUtilisateur].Adresses;
                }
                else
                {
                    GetUtilisateurById(user.IdUtilisateur);
                    user.Adresses = _utilisateurDictionary[user.IdUtilisateur].Adresses;
                }
            }
        }


        public static Utilisateur GetUtilisateurById(string id, bool initializer = true)
        {
            if (UtilisateurAlreadyInDictionary(id))
            {
                return _utilisateurDictionary[id];
            }

            UtilisateurDAO udao = UtilisateurDAL.SelectUtilisateurById(id);
            PersonneDAO pdao = PersonneDAL.SelectPersonneById(udao.PersonneId);

            List<Adresse> listeAdresse = new List<Adresse>();

            if (initializer)
            {
                foreach (var adresse_in_dao in pdao.Adresses)
                {
                    Adresse adresse = AdresseORM.GetAdresseById(adresse_in_dao, false);
                    listeAdresse.Add(adresse);
                }
            }

            Utilisateur user = new Utilisateur(udao.IdUtilisateur, udao.VerifSolvable, udao.VerifRessortissant,
                udao.VerifIdentite, udao.ListeMotClef, pdao.IdPersonne, pdao.Nom, pdao.Prenom, pdao.Age, pdao.Email,
                pdao.Password, pdao.TelephoneMobile, pdao.TelephoneFixe, listeAdresse);


            if (initializer)
            {
                _utilisateurDictionary[user.IdUtilisateur] = user;
                AdresseORM.populateMTM(user.Adresses);
            }

            return user;
        }


        public static List<Utilisateur> getAllUtilisateur()
        {
            List<UtilisateurDAO> ludao = UtilisateurDAL.SelectAllUtilisateur();
            List<Utilisateur> users = new List<Utilisateur>();
            
            foreach (var udao in ludao)
            {
                users.Add(GetUtilisateurById(udao.IdUtilisateur));
            }
            return users;
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