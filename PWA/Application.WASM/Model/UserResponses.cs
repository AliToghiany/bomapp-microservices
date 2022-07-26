namespace Application.WASM.Model
{
    public class RequestConfirmCode
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }
    public class ResponseConfirmCode
    {
        public long UserId { get; set; }
        public bool IsNew { get; set; }
        public string? Token { get; set; }
    }
}
