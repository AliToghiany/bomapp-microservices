using AutoMapper;
using dotnet_lib.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Entity;

namespace wpf_lib.Profiler
{
    public class AppProfiler:Profile
    {
        public AppProfiler()
        {
           
            CreateMap<User, ResponseUser>().ReverseMap();
            CreateMap<User, GetMyUserProfileResponse>().ReverseMap();
        }
    }
}
