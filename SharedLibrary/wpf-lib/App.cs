using dotnet_lib.Services.Interface;
using dotnet_lib.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_lib;
using wpf_lib.Interface;
using wpf_lib.Service;
using wpf_lib.Context;
using System.Reflection;


namespace wpf_lib
{
    public static class App
    {
        public static string Token="";
        public static long UserId;
        public static void RegisterWpfLibraryService(this IServiceCollection services)
        {
            services.RegisterLibraryApp();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ApplicationDbContext>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
