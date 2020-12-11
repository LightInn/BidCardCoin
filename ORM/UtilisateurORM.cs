using System.Collections.Generic;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public static class UtilisateurORM
    {
        private static readonly Dictionary<string, Utilisateur> UtilisateurDictionary = new Dictionary<string, Utilisateur>();

        private static bool UtilisateurAlreadyInDictionary(string id)
        {
            return UtilisateurDictionary.ContainsKey(id);
        }

        public static void PopulateMtm(List<Utilisateur> users)
        {
            // liste des utilisateurs qui on beusoin de se faire peupler (leurs liste adresses)

            foreach (var user in users)
            {
                if (UtilisateurAlreadyInDictionary(user.IdUtilisateur))
                {
                    user.Adresses = UtilisateurDictionary[user.IdUtilisateur].Adresses;
                }
                else
                {
                    GetUtilisateurById(user.IdUtilisateur);
                    user.Adresses = UtilisateurDictionary[user.IdUtilisateur].Adresses;
                }
            }
        }

        public static Utilisateur GetUtilisateurById(string id, bool initializer = true)
        {
            if (UtilisateurAlreadyInDictionary(id))
            {
                return UtilisateurDictionary[id];
            }

            UtilisateurDAO udao = UtilisateurDAL.SelectUtilisateurById(id);
            PersonneDAO pdao = PersonneDAL.SelectPersonneById(udao.PersonneId);

            List<Adresse> listeAdresse = new List<Adresse>();

            if (initializer)
            {
                foreach (var adresseInDAO in pdao.Adresses)
                {
                    Adresse adresse = AdresseORM.GetAdresseById(adresseInDAO, false);
                    listeAdresse.Add(adresse);
                }
            }

            Utilisateur user = new Utilisateur(udao.IdUtilisateur, udao.VerifSolvable, udao.VerifRessortissant,
                udao.VerifIdentite, udao.ListeMotClef, pdao.IdPersonne, pdao.Nom, pdao.Prenom, pdao.Age, pdao.Email,
                pdao.Password, pdao.TelephoneMobile, pdao.TelephoneFixe, listeAdresse);


            if (initializer)
            {
                UtilisateurDictionary[user.IdUtilisateur] = user;
                AdresseORM.PopulateMtm(user.Adresses);
            }

            return user;
        }

        public static List<Utilisateur> GetAllUtilisateur()
        {
            List<UtilisateurDAO> ludao = UtilisateurDAL.SelectAllUtilisateur();
            List<Utilisateur> users = new List<Utilisateur>();

            foreach (var udao in ludao)
            {
                users.Add(GetUtilisateurById(udao.IdUtilisateur));
            }

            return users;
        }

        static UtilisateurDAO UtilisateurToDao(Utilisateur user)
        {
            return new UtilisateurDAO(user.IdUtilisateur, user.IdPersonne, user.IsSolvable, user.IsRessortissant,
                user.IdentityExist, user.ListeMotClef);
        }

        static void AddUtilisateur(Utilisateur user)
        {
            UtilisateurDAL.InsertNewUtilisateur(UtilisateurToDao(user));
        }

        static void UpdateUtilisateur(Utilisateur user)
        {
            UtilisateurDAL.UpdateUtilisateur(UtilisateurToDao(user));
        }

        static void DeleteUtilisateur(Utilisateur user)
        {
            UtilisateurDAL.DeleteUtilisateur(user.IdUtilisateur);
        }
    }
}