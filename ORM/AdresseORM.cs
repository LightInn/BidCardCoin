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
    public class AdresseORM
    {
        private static Dictionary<string, Adresse> _adressesDictionary = new Dictionary<string, Adresse>();

        private static bool AdresseAlreadyInDictionary(string id)
        {
            return _adressesDictionary.ContainsKey(id);
        }

        public static void populateMTM(List<Adresse> adresses)
        {
            // liste des adresses qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var adresse in adresses)
            {
                if (AdresseAlreadyInDictionary(adresse.IdAdresse))
                {
                    adresse.Utilisateurs = _adressesDictionary[adresse.IdAdresse].Utilisateurs;
                }
                else
                {
                    GetAdresseById(adresse.IdAdresse);
                    adresse.Utilisateurs = _adressesDictionary[adresse.IdAdresse].Utilisateurs;
                }
            }
        }


        public static Adresse GetAdresseById(string id, bool initializer = true)
        {
            AdresseDAO adao = AdresseDAL.SelectAdresseById(id);
            List<Utilisateur> listeUsers = new List<Utilisateur>();

            if (initializer)
            {
                foreach (var personneid in adao.ListePersonneId)
                {
                    Utilisateur user =
                        UtilisateurORM.GetUtilisateurById(PersonneDAL.getChildReference(personneid), false);
                    listeUsers.Add(user);
                }
            }


            Adresse adresse = new Adresse(adao.IdAdresse, adao.Pays, adao.Region, adao.Ville, adao.CodePostal,
                adao.Adresse, listeUsers);


            if (initializer)
            {
                _adressesDictionary[adresse.IdAdresse] = adresse;
                UtilisateurORM.PopulateMtm(adresse.Utilisateurs);
            }

            return adresse;
        }


        public static List<Adresse> GetAllAdresse()
        {
            List<AdresseDAO> ladao = AdresseDAL.SelectAllAdresse();
            List<Adresse> adresses = new List<Adresse>();

            foreach (var adao in ladao)
            {
                adresses.Add(GetAdresseById(adao.IdAdresse));
            }

            return adresses;
        }

        static AdresseDAO AdresseToDao(Adresse adresse)
        {
            return new AdresseDAO(adresse.IdAdresse, adresse.Pays, adresse.Region, adresse.Ville, adresse.CodePostal,
                adresse.AdresseNb, adresse.Utilisateurs.Select(user => user.IdUtilisateur).ToList());
        }

        static void AddAdresse(Adresse user)
        {
            AdresseDAL.InsertOrAddNewAdresse(AdresseToDao(user));
        }

        static void UpdateAdresse(Adresse user)
        {
            AdresseDAL.InsertOrAddNewAdresse(AdresseToDao(user));
        }

        static void DeleteAdresse(Adresse user)
        {
            AdresseDAL.DeleteAdresse(user.IdAdresse);
        }
    }
}