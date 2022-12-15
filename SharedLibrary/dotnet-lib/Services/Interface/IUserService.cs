using dotnet_lib.Models;
using dotnet_lib.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Services.Interface
{
    public interface IUserService
    {
        Task<ResultDto<GetMyUserProfileResponse>> GetMyUserProfileResponseAsync();
        Task<ResultDto<ResponseUser>> GetUser(long Id);

    }
}
