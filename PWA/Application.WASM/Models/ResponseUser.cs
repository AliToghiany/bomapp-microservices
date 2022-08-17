namespace Application.WASM.Models
{
    public class ResponseUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<ImagesProfileResponse> ImagesProfileResponses { get; set; }

    }
}
