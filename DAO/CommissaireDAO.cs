namespace bidCardCoin.DAO
{
    public class CommissaireDAO
    {
        public CommissaireDAO()
        {
        }

        public CommissaireDAO(string idCommissaire, string personneId)
        {
            IdCommissaire = idCommissaire;
            PersonneId = personneId;
        }

        public string IdCommissaire { get; }
        public string PersonneId { get; }
    }
}