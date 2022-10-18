using Chat.Domain.Entities.GroupE;
using Chat.Domain.Entities.MessageE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Chat.Domain.Entities.MessageE.File;

namespace Chat.Infrastructure.Persistense
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupBanUser> GroupBanUsers { get; set; }
        public DbSet<GroupProfile> GroupProfiles { get; set; }
        public DbSet<Join> Joins { get; set; }
        public DbSet<Seen> Seens { get; set; }
    }
}
