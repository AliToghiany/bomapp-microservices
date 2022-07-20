using Chat.Domain.Entities.GroupE;
using Chat.Domain.Entities.MessageE;
using Chat.Domain.Entities.UserE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure.Persistense
{
    class ChatDBContext:DbContext
    {
        public ChatDBContext(DbContextOptions<ChatDBContext> options):base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
