namespace Application.WASM.IndexDbEntities
{
    public class Group
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public string GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public int NewMessage { get; set; }
       



    }
}
