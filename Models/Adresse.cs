namespace BidCardCoin.Models
{
    public class Adresse
    {
        private string _idAdresse;
        private string _pays;
        private string _region;
        private string _ville;
        private string _codePostal;
        private string _adresse;

        public Adresse(string idAdresse, string pays, string region, string ville, string codePostal, string adresse)
        {
            this._idAdresse = idAdresse;
            this._pays = pays;
            this._region = region;
            this._ville = ville;
            this._codePostal = codePostal;
            this._adresse = adresse;
        }
    }
}