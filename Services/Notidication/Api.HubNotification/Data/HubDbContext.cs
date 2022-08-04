using Api.HubNotification.Entitiest;
using Microsoft.EntityFrameworkCore;

namespace Api.HubNotification.Data
{
    public class HubDbContext:DbContext
    {
        public HubDbContext()
        {


        }
        public HubDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Connection> Connections { get; set; }
    }
}
