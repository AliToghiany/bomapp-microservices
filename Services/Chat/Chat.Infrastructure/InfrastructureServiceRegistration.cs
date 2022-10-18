using Chat.Application.Contracts.Persisence;
using Chat.Infrastructure.Persistense;
using Chat.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddDbContext<ChatDbContext>(options => options.UseSqlServer(configuration["DatabaseSettings:DbContextConnectionString"]));
        
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
