namespace BidCardCoin.Models
{
    public class Commissaire
    {
        private string _idCommissaire;
        private Personne _personne;

        public Commissaire(string idCommissaire, Personne personne)
        {
            this._idCommissaire = idCommissaire;
            this._personne = personne;
        }
    }
}