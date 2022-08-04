namespace Catalog.Api.Entities
{
    public class Votes
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual Game Game { get; set; }
        public long GameId { get; set; }
        public int Voet { get; set; }
    }
}
