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
    public class CommissaireORM
    {
        // private static Dictionary<string, Commissaire> _commissairesDictionary = new Dictionary<string, Commissaire>();
        // private static bool CommissaireAlreadyInDictionary(string id)
        // {
        //     return _commissairesDictionary.ContainsKey(id);
        // }
        // // todo - bré est en train de le faire normalement
        // public static void Populate(List<Commissaire> commissaires)
        // {
        //     // todo
        // }
        // public static void Populate(Commissaire commissaire)
        // {
        //     // todo
        // }
        //
        // public static Commissaire GetCommissaireById(string id, bool initializer = true)
        // {
        //     // todo
        //     Commissaire commissaire = new Commissaire();
        //
        //     return commissaire;
        // }
        
        private static readonly Dictionary<string, Commissaire> CommissaireDictionary =
            new Dictionary<string, Commissaire>();

        private static bool CommissaireAlreadyInDictionary(string id)
        {
            return CommissaireDictionary.ContainsKey(id);
        }

        public static void Populate(List<Commissaire> users)
        {
            // liste des commissaires qui on beusoin de se faire peupler (leurs liste adresses)

            foreach (var user in users)
            {
                if (!CommissaireAlreadyInDictionary(user.IdCommissaire))
                {
                    GetCommissaireById(user.IdCommissaire);
                }
                
                user.Adresses = CommissaireDictionary[user.IdCommissaire].Adresses;
                
            }
        }

        public static Commissaire GetCommissaireById(string id, bool initializer = true)
        {
            if (CommissaireAlreadyInDictionary(id))
            {
                return CommissaireDictionary[id];
            }

            CommissaireDAO cdao = CommissaireDAL.SelectCommissaireById(id);
            PersonneDAO pdao = PersonneDAL.SelectPersonneById(cdao.PersonneId);

            List<Adresse> listeAdresse = new List<Adresse>();

            if (initializer)
            {
                foreach (var adresseInDAO in pdao.Adresses)
                {
                    Adresse adresse = AdresseORM.GetAdresseById(adresseInDAO, false);
                    listeAdresse.Add(adresse);
                }
            }

            Commissaire user = new Commissaire(cdao.IdCommissaire, pdao.IdPersonne, pdao.Nom, pdao.Prenom, pdao.Age, pdao.Email,
                pdao.Password, pdao.TelephoneMobile, pdao.TelephoneFixe, listeAdresse);


            if (initializer)
            {
                CommissaireDictionary[user.IdCommissaire] = user;
                AdresseORM.Populate(user.Adresses);
            }

            return user;
        }

        public static List<Commissaire> GetAllCommissaire()
        {
            List<CommissaireDAO> ludao = CommissaireDAL.SelectAllCommissaire();
            List<Commissaire> users = new List<Commissaire>();

            foreach (var udao in ludao)
            {
                users.Add(GetCommissaireById(udao.IdCommissaire));
            }

            return users;
        }

        static CommissaireDAO CommissaireToDao(Commissaire user)
        {
            return new CommissaireDAO(user.IdCommissaire, user.IdPersonne);
        }

        public static void AddOrUpdateCommissaire(Commissaire user)
        {
            PersonneDAO test = PersonneDAL.SelectPersonneById(user.IdPersonne);
            if (test.IdPersonne == null)
            {
                PersonneDAL.InsertNewPersonne(new PersonneDAO(user.IdPersonne, user.Nom, user.Prenom, user.Age,
                    user.Email,
                    user.Password, user.TelephoneMobile, user.TelephoneMobile,
                    user.Adresses.Select(adress => adress.IdAdresse).ToList()));
            }

            CommissaireDAL.InsertOrAddNewCommissaire(CommissaireToDao(user));
        }

        public static void DeleteCommissaire(Commissaire user)
        {
            CommissaireDAL.DeleteCommissaire(user.IdCommissaire);
        }
    }
}
