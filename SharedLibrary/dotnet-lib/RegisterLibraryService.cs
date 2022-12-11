using dotnet_lib.Services.Interface;
using dotnet_lib.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_lib.Utitlities;
using System.Net.Http.Headers;

namespace dotnet_lib
{
    public static class RegisterLibraryService
    {
        public static void RegisterLibraryApp(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthService, AuthService>
             (c => c.BaseAddress = new Uri(ServerUtilities.GATEWAYURL));
            services.AddHttpClient<IUserService, UserService>
            (c => c.BaseAddress = new Uri(ServerUtilities.GATEWAYURL));
            services.AddHttpClient<ISearchService, SearchService>
            (c => c.BaseAddress = new Uri(ServerUtilities.GATEWAYURL));
        }
    }
}
