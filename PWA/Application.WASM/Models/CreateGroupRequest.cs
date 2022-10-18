namespace Application.WASM.Models
{
    public class CreateGroupRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupNamr { get; set; }
        public List<long> DefualtUser { get; set; }
        public string ImageGroupUrl { get; set; }
    }
}
