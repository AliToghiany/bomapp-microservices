using Anbarbomapp.Shared.Dtos.Account;

namespace Anbarbomapp.Client.Shared.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task SignIn(SignInRequestDto dto);

        Task SignOut();
    }
}