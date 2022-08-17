namespace Application.WASM.IndexDbEntities
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public long UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string LastImageProfile { get; set; }
        public long ContactId { get; set;}
        public string ContactName { get; set; }

     
    }
}
