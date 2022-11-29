using Anbarbomapp.Server.Api.Models.Account;
using Anbarbomapp.Shared.Dtos.Account;

namespace Anbarbomapp.Server.Api.Services.Contracts
{
    public interface IJwtService
    {
        Task<SignInResponseDto> GenerateToken(User user);
    }
}