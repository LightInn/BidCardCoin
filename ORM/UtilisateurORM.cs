using System.Collections.Generic;
using System.Linq;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public static class UtilisateurORM
    {
        private static readonly Dictionary<string, Utilisateur> UtilisateurDictionary =
            new Dictionary<string, Utilisateur>();

        private static bool UtilisateurAlreadyInDictionary(string id)
        {
            return UtilisateurDictionary.ContainsKey(id);
        }

        public static void Populate(List<Utilisateur> users)
        {
            // liste des utilisateurs qui on beusoin de se faire peupler (leurs liste adresses)

            foreach (var user in users)
            {
                if (!UtilisateurAlreadyInDictionary(user.IdUtilisateur)) GetUtilisateurById(user.IdUtilisateur);


                user.Adresses = UtilisateurDictionary[user.IdUtilisateur].Adresses;
            }
        }

        public static Utilisateur GetUtilisateurById(string id, bool initializer = true)
        {
            if (UtilisateurAlreadyInDictionary(id)) return UtilisateurDictionary[id];

            var udao = UtilisateurDAL.SelectUtilisateurById(id);
            var pdao = PersonneDAL.SelectPersonneById(udao.PersonneId);

            var listeAdresse = new List<Adresse>();

            if (initializer)
                foreach (var adresseInDAO in pdao.Adresses)
                {
                    var adresse = AdresseORM.GetAdresseById(adresseInDAO, false);
                    listeAdresse.Add(adresse);
                }

            var user = new Utilisateur(udao.IdUtilisateur, udao.VerifSolvable, udao.VerifRessortissant,
                udao.VerifIdentite, udao.ListeMotClef, pdao.IdPersonne, pdao.Nom, pdao.Prenom, pdao.Age, pdao.Email,
                pdao.Password, pdao.TelephoneMobile, pdao.TelephoneFixe, listeAdresse);


            if (initializer)
            {
                UtilisateurDictionary[user.IdUtilisateur] = user;
                AdresseORM.Populate(user.Adresses);
            }

            return user;
        }

        public static List<Utilisateur> GetAllUtilisateur()
        {
            var ludao = UtilisateurDAL.SelectAllUtilisateur();
            var users = new List<Utilisateur>();

            foreach (var udao in ludao) users.Add(GetUtilisateurById(udao.IdUtilisateur));

            return users;
        }

        private static UtilisateurDAO UtilisateurToDao(Utilisateur user)
        {
            return new UtilisateurDAO(user.IdUtilisateur, user.IdPersonne, user.IsSolvable, user.IsRessortissant,
                user.IdentityExist, user.ListeMotClef);
        }


        private static PersonneDAO UtilisateurToPersonneDao(Utilisateur user)
        {
            return new PersonneDAO(user.IdPersonne, user.Nom, user.Prenom, user.Age, user.Email, user.Password,
                user.TelephoneMobile, user.TelephoneFixe, user.Adresses.Select(adress => adress.IdAdresse).ToList());
        }

        public static void AddUtilisateur(Utilisateur user)
        {
            var test = PersonneDAL.SelectPersonneById(user.IdPersonne);
            if (test.IdPersonne == null) PersonneDAL.InsertNewPersonne(UtilisateurToPersonneDao(user));

            UtilisateurDAL.InsertNewUtilisateur(UtilisateurToDao(user));
        }

        public static void UpdateUtilisateur(Utilisateur user)
        {
            PersonneDAL.UpdatePersonne(UtilisateurToPersonneDao(user));
            UtilisateurDAL.UpdateUtilisateur(UtilisateurToDao(user));
        }

        public static void DeleteUtilisateur(Utilisateur user)
        {
            UtilisateurDAL.DeleteUtilisateur(user.IdUtilisateur);
        }
    }
}