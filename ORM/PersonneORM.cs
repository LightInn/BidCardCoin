using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;


namespace BidCardCoin
{
    public class PersonneORM
    {
        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO = PersonneDAO.getPersonne(idPersonne);
            int idMetier = pDAO.idMetierPersonneDAO;
            MetierViewModel m = MetierORM.getMetier(idMetier);
            PersonneViewModel p = new PersonneViewModel(pDAO.idPersonneDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO,
                m, pDAO.dateNaisPersonneDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
                int idMetier = element.idMetierPersonneDAO;

                MetierViewModel
                    m = MetierORM.getMetier(idMetier); // Plus propre que d'aller chercher le métier dans la DAO.
                PersonneViewModel p = new PersonneViewModel(element.idPersonneDAO, element.nomPersonneDAO,
                    element.prenomPersonneDAO, m, element.dateNaisPersonneDAO);
                l.Add(p);
            }

            return l;
        }


        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty,
                p.prenomPersonneProperty, p.MetierPersonneProperty.idMetier, p.DateNaisPersonneProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty,
                p.prenomPersonneProperty, p.MetierPersonneProperty.idMetier, p.DateNaisPersonneProperty));
        }
    }
}