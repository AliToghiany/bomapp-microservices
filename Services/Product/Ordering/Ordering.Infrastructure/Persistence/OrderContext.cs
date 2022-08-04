using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;

using Ordering.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions options):base(options)
        {

        }
    
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> Details { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State==EntityState.Modified) { 
                
                        entry.Entity.UpdateTime = DateTime.Now;
                        entry.Entity.LastModifiedBy = "swn";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
