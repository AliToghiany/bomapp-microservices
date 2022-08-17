using WebAppApiGW.Extentions;
using WebAppApiGW.Models;

namespace WebAppApiGW.Services
{
    public interface IUserService
    {
        Task<ResponseUser> GetUser(long userId);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseUser> GetUser(long userId)
        {
            var res = await _httpClient.GetAsync("/User/GetUserById");
            return await res.ReadContentAs<ResponseUser>();
        }
    }
}
