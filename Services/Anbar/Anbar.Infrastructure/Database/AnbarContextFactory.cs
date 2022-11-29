using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Infrastructure.Database
{
    internal class AnbarContextFactory : IDesignTimeDbContextFactory<AnbarContext>
    {
        public AnbarContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnbarContext>();
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=anbardb;User Id=SA;Password=774078haT&");

            return new AnbarContext(optionsBuilder.Options);
        }
    }
}
