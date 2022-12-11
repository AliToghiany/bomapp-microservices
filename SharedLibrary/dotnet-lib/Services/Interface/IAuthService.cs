using dotnet_lib.Models;
using dotnet_lib.Models.Request;
using dotnet_lib.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Services.Interface
{
    public interface IAuthService
    {
      Task<ResultDto<ResponseSendCode>> GetAuthIdAsync(string phone);
      Task<ResultDto<SignUserResponse>> ConfirmCodeAsync(SignUserRequest signUserRequest);
    }
}
