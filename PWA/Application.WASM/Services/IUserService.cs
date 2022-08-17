using Application.WASM.Extentions;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;
using Application.WASM.Model;
using Application.WASM.Models;
using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace Application.WASM.Services
{
    public interface IUserService
    {
        Task<ResponseDto<Guid>> SendCode(string phone);
        Task<ResponseDto<ResponseConfirmCode>> ConfirmCode(Guid id, string code);
        Task<ResponseUser> GetUser(long userId);
        Task<bool> UpdateUser(RequestUpdateUser requestUpdateUser);
    }
    public class UserService : IUserService
    {
        private HttpClient _httpClient;
        private readonly ILocalStorageService _localStore;
        public UserService(HttpClient httpClient, ILocalStorageService localStore)
        {
            _httpClient = httpClient;
            _localStore = localStore;
        }

        public async Task<ResponseDto<Guid>> SendCode(string phone)
        {

            var res = await _httpClient.PostAsJsonAsync("/Auth/SendCode", phone);
            if (res.IsSuccessStatusCode)
            {
                return new ResponseDto<Guid>
                {
                    Data = await res.ReadContentAs<Guid>(),
                    Success = true
                };

            }

            return new ResponseDto<Guid>
            {
                Success = false,
                Message = "The Entered Phone is not Correct"
            };

        }

        public async Task<ResponseDto<ResponseConfirmCode>> ConfirmCode(Guid id, string code)
        {

            var res = await _httpClient.PostAsJsonAsync("/Auth/ConfirmCode", new RequestConfirmCode { Id = id, Code = code });
            if (res.IsSuccessStatusCode)
            {
                return new ResponseDto<ResponseConfirmCode> { Data = await res.ReadContentAs<ResponseConfirmCode>(), Success = true };
            }
            return new ResponseDto<ResponseConfirmCode>
            {
                Success = false,
                Message = "The Entered Code is not Correct"
            };

        }

        public async Task<ResponseUser> GetUser(long userId)
        {
            
            var res = await _httpClient.GetAsync("/User/GetUserById");
            return await res.ReadContentAs<ResponseUser>();


        }

        public async Task<bool> UpdateUser(RequestUpdateUser requestUpdateUser)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",await _localStore.GetItemAsync<string>("token"));
            var res = await _httpClient.PostAsJsonAsync("/User/UpdateUser", requestUpdateUser);
            return res.IsSuccessStatusCode;
        }
    }
}
