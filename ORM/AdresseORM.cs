using System.Collections.Generic;
using System.Linq;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class AdresseORM
    {
        private static readonly Dictionary<string, Adresse> AdressesDictionary = new Dictionary<string, Adresse>();

        private static bool AdresseAlreadyInDictionary(string id)
        {
            return AdressesDictionary.ContainsKey(id);
        }

        public static void Populate(List<Adresse> adresses)
        {
            // liste des adresses qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var adresse in adresses)
                if (AdresseAlreadyInDictionary(adresse.IdAdresse))
                {
                    adresse.Utilisateurs = AdressesDictionary[adresse.IdAdresse].Utilisateurs;
                }
                else
                {
                    GetAdresseById(adresse.IdAdresse);
                    adresse.Utilisateurs = AdressesDictionary[adresse.IdAdresse].Utilisateurs;
                }
        }


        public static Adresse GetAdresseById(string id, bool initializer = true)
        {
            var adao = AdresseDAL.SelectAdresseById(id);
            var listeUsers = new List<Utilisateur>();

            if (initializer)
                foreach (var personneid in adao.ListePersonneId)
                {
                    var user =
                        UtilisateurORM.GetUtilisateurById(PersonneDAL.getChildReference(personneid), false);
                    listeUsers.Add(user);
                }


            var adresse = new Adresse(adao.IdAdresse, adao.Pays, adao.Region, adao.Ville, adao.CodePostal,
                adao.Adresse, listeUsers);


            if (initializer)
            {
                AdressesDictionary[adresse.IdAdresse] = adresse;
                UtilisateurORM.Populate(adresse.Utilisateurs);
            }

            return adresse;
        }


        public static List<Adresse> GetAllAdresse()
        {
            var ladao = AdresseDAL.SelectAllAdresse();
            var adresses = new List<Adresse>();

            foreach (var adao in ladao) adresses.Add(GetAdresseById(adao.IdAdresse));

            return adresses;
        }

        private static AdresseDAO AdresseToDao(Adresse adresse)
        {
            return new AdresseDAO(adresse.IdAdresse, adresse.Pays, adresse.Region, adresse.Ville, adresse.CodePostal,
                adresse.AdresseNb, adresse.Utilisateurs.Select(user => user.IdUtilisateur).ToList());
        }

        public static void AddAdresse(Adresse user)
        {
            AdresseDAL.InsertOrAddNewAdresse(AdresseToDao(user));
        }

        public static void UpdateAdresse(Adresse user)
        {
            AdresseDAL.InsertOrAddNewAdresse(AdresseToDao(user));
        }

        public static void DeleteAdresse(Adresse user)
        {
            AdresseDAL.DeleteAdresse(user.IdAdresse);
        }
    }
}