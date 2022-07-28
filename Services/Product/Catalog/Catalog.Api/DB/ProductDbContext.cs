using Catalog.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.DB
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Votes> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
