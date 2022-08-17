using Chat.Domain.Entities.GroupE;
using Chat.Domain.Entities.MessageE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Persistense
{
    public class ChatDbContext:DbContext
    {
        public ChatDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Message> Messages { get; }
        public DbSet<File> Files { get; }
        public DbSet<Group> Groups { get; }
        public DbSet<GroupBanUser> GroupBanUsers { get; }
        public DbSet<GroupProfile> GroupProfiles { get; }
        public DbSet<Join> Joins { get; }
        public DbSet<Seen> Seens { get; }
    }
}
