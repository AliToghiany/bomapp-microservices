namespace Application.WASM.IndexDbEntities
{
    public class GroupProfile
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public string Path { get; set; }

        public string Name { get; set; }

        public long Groupe_Id { get; set; }
    }
}
