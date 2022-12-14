using dotnet_lib.Models;
using dotnet_lib.Models.Response;
using dotnet_lib.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Entity;

namespace wpf_lib.Interface
{
    public interface IUserRepository
    {
        Task<ResultDto<ResponseUser>> GetUser(long Id);
        Task<ResultDto<GetMyUserProfileResponse>> GetMyUserProfile();
        Task<ResultDto<AppResponseChatSearch>> GetLastSearchAsync();
        Task<ResultDto> UpdateUser(ResponseUser responseUser);
        Task<ResultDto> UpdateUser(GetMyUserProfileResponse responseUser);
    }
}
