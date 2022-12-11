
using dotnet_lib.Models;
using dotnet_lib.Models.Response;
using dotnet_lib.Services.Interface;
using dotnet_lib.Utitlities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Services
{
    public class UserService : BaseService,IUserService
    {



      

        public UserService(HttpClient httpClient) : base(httpClient)
        {
         
        }
     
        public async Task<ResultDto<GetMyUserProfileResponse>> GetMyUserProfileResponseAsync()
        {
            
         
                var res = await _httpClient.GetAsync("/user/getmyprofile");
                return await res.ToResultdto<GetMyUserProfileResponse>();
            
           
        }

    }
}
