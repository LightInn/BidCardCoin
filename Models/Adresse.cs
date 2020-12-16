using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using bidCardCoin.ORM;

namespace BidCardCoin.Models
{
    public class Adresse : INotifyPropertyChanged
    {
        private string _adresse;
        private string _codePostal;
        private string _idAdresse;
        private string _pays;

        private string _region;
        private List<Utilisateur> _utilisateurs;
        private string _ville;

        public Adresse()
        {
        }

        public Adresse(string idAdresse, string pays, string region, string ville, string codePostal, string adresse,
            List<Utilisateur> users)
        {
            _idAdresse = idAdresse;
            _pays = pays;
            _region = region;
            _ville = ville;
            _codePostal = codePostal;
            _adresse = adresse;
            _utilisateurs = users;
        }

        public string IdAdresse
        {
            get => _idAdresse;
            set
            {
                _idAdresse = value;
                OnPropertyChanged();
            }
        }

        public string Pays
        {
            get => _pays;
            set
            {
                _pays = value;
                OnPropertyChanged();
            }
        }

        public string Region
        {
            get => _region;
            set
            {
                _region = value;
                OnPropertyChanged();
            }
        }

        public string Ville
        {
            get => _ville;
            set
            {
                _ville = value;
                OnPropertyChanged();
            }
        }


        public string CodePostal
        {
            get => _codePostal;
            set
            {
                _codePostal = value;
                OnPropertyChanged();
            }
        }

        public string AdresseNb
        {
            get => _adresse;
            set
            {
                _adresse = value;
                OnPropertyChanged();
            }
        }

        public List<Utilisateur> Utilisateurs
        {
            get => _utilisateurs;
            set
            {
                _utilisateurs = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
                AdresseORM.UpdateAdresse(this);
            }
        }
    }
}