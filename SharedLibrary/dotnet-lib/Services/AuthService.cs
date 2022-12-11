using dotnet_lib.Models;
using dotnet_lib.Models.Request;
using dotnet_lib.Models.Response;
using dotnet_lib.Services.Interface;
using dotnet_lib.Utitlities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultDto<ResponseSendCode>> GetAuthIdAsync(string phone)
        {
            string jsonCustomer = JsonConvert.SerializeObject(new ConfirmUserRequest() { Phone=phone});
            StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(ServerUtilities.GATEWAYURL + "/auth/sendcode", content);
            return await res.ToResultdto<ResponseSendCode>();

        }
        public async Task<ResultDto<SignUserResponse>> ConfirmCodeAsync(SignUserRequest signUserRequest)
        {
            string jsonCustomer = JsonConvert.SerializeObject(signUserRequest);
            StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(ServerUtilities.GATEWAYURL + "/auth/confirmcode", content);
            return await res.ToResultdto<SignUserResponse>();
        }
    }
}
