using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Persistense
{
    internal class ChatDbContextFactory : IDesignTimeDbContextFactory<ChatDbContext>
    {
        public ChatDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=chatdb;User Id=SA;Password=774078haT&");

            return new ChatDbContext(optionsBuilder.Options);
        }
    
    }
}
