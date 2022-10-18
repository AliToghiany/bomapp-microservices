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
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=chatdb;Integrated Security=True;User Instance=True");

            return new ChatDbContext(optionsBuilder.Options);
        }
    
    }
}
