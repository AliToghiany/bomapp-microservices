using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Context
{
    internal class IdentityDBContextFactory : IDesignTimeDbContextFactory<IdentityDBContext>
    {
        public IdentityDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDBContext>();
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=identitydb;User Id=SA;Password=774078haT&");

            return new IdentityDBContext(optionsBuilder.Options);
        }
    }
}
