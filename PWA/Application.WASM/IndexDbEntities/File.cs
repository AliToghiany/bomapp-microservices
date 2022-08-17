namespace Application.WASM.IndexDbEntities
{
    public class File
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public string FileId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}
