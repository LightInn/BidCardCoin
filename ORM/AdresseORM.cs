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
        public static List<Personne> listeIdToListePersonne(List<string> listeId)
        {
            List<Personne> listePersonne = new List<Personne>();
            foreach (var elem in listeId)
            {
                // vérifie dans la collection de personne, si la personne existe déjà, on la creer si ce n'est pas le cas
                // puis on l'ajoute à la liste de personne
                // todo voir ça
                //listePersonne.Add(PersonneORM.getPersonneById(elem));
            }
            return listePersonne;
        }
        public static List<string> listePersonneToListeId(List<Personne> listePersonne)
        {
            List<string> listeId = new List<string>();
            foreach (var elem in listeId)
            {
                // vérifie dans la collection de personne, si la personne existe déjà, on la creer si ce n'est pas le cas
                // puis on l'ajoute à la liste de personne
                // todo voir ça
                //listePersonne.Add(PersonneORM.getPersonneById(elem));
                //
            }
            return listeId;
        }
        
        public static Adresse getAdresse(string idAdresse)
        {
            AdresseDAO adresseDao = AdresseDAL.SelectAdresseById(idAdresse);
            Adresse adresse = new Adresse(adresseDao.IdAdresse,adresseDao.Pays, adresseDao.Region,
                adresseDao.Ville,adresseDao.CodePostal,adresseDao.Adresse,new List<Personne>());
            List<Personne> listePersonne = listeIdToListePersonne(adresseDao.ListePersonneId);
            return adresse;
        }

        public static void insertOrUpdateAdresse(Adresse adresse)
        {
            AdresseDAL.InsertOrAddNewAdresse(new AdresseDAO(adresse.IdAdresse,adresse.Pays,adresse.Region,adresse.Ville
                ,adresse.CodePostal,adresse.AdresseNom,listePersonneToListeId(adresse.ListePersone)));
        }
    }
}
