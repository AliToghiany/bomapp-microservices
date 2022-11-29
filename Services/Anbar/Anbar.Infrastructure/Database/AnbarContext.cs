using Anbar.Domain.Commodities;
using Anbar.Domain.Commodities.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Infrastructure.Database
{
    public class AnbarContext:DbContext
    {
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AnbarContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnbarContext).Assembly);
        }
    }
}
