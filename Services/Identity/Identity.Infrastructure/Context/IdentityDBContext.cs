using Identity.Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Context
{
    public class IdentityDBContext:IdentityDbContext<User,Role,long>
    {
        public DbSet<Confirm> Confirms { get; set; }
        public DbSet<UserImages> UserImages  { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public IdentityDBContext(DbContextOptions options):base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin" });
            builder.Entity<Role>().HasData(new Role { Id = 2, Name = "Operator" });
            builder.Entity<Role>().HasData(new Role { Id = 3, Name = "Customer" });
            builder.Entity<User>().HasIndex(p => p.PhoneNumber).IsUnique();
            builder.Entity<User>().HasMany(p => p.MyContacts).WithOne(p => p.ForUser);
            builder.Entity<User>().HasMany(p => p.ToContacts).WithOne(p => p.WithUser);
            base.OnModelCreating(builder);
        }
    }
}
