using MediatR;

namespace Identity.Application.Feature.Users.Command.SignUser
{
    public class SignUserResponse
    {
        public long UserId { get; set; }
        public bool IsNew { get; set; }
        public string? Token { get; set; }
    }


}
