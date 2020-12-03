using System;
using System.ComponentModel;

namespace BidCardCoin.Models
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        private int idPersonne;
        private string nomPersonne;
        private string prenomPersonne;
        private MetierViewModel metierPersonne;
        private DateTime dateNaisPersonne;
        private string concat = "Ajouter ";


        private int age;

        public PersonneViewModel() { }

        public PersonneViewModel(int id, string nom, string prenom, MetierViewModel metier, DateTime dateNaisPersonne)
        {
            this.idPersonne = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.metierPersonne = metier;
            this.dateNaisPersonne = dateNaisPersonne;
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
            set
            {
                idPersonne = value;
            }
        }
        public String nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value.ToUpper();
                ConcatProperty = "Ajouter " + nomPersonne + " " + prenomPersonne;
                OnPropertyChanged("nomPersonneProperty"); // indique au système de binding que la valeur a changé
            }

        }
        public String prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value;
                ConcatProperty = "Ajouter " + nomPersonne +" "+ prenomPersonne;
                OnPropertyChanged("prenomPersonneProperty");
            }
        }

        public MetierViewModel MetierPersonneProperty
        {
            get { return metierPersonne; }
            set
            {
                metierPersonne = value;
            }
        }

        public DateTime DateNaisPersonneProperty { get => dateNaisPersonne; set => dateNaisPersonne = value; }

        public int AgeProperty
        {
            get { return age; }
            set
            {
                this.age = value;
                OnPropertyChanged("AgeProperty");
            }
        }

        public string ConcatProperty
        {
            get { return concat; }
            set
            {
                this.concat = value;
                OnPropertyChanged("ConcatProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                if ((info != "AgeProperty")&&(MainWindow.onglet != "ajouter"))
                {
                    PersonneORM.updatePersonne(this);
                }
            }
        }
    }
}