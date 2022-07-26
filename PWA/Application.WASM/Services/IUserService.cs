using Application.WASM.Extentions;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;
using Application.WASM.Model;

namespace Application.WASM.Services
{
    public interface IUserService
    {
        Task<ResponseDto<Guid>> SendCode(string phone);
        Task<ResponseDto<ResponseConfirmCode>> ConfirmCode(Guid id, string code);
    }
    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
      
    }
}
