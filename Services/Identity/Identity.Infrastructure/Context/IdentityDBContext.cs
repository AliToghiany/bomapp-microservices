﻿using Identity.Domain.User;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
