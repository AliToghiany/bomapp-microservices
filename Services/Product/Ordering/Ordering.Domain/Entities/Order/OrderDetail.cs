using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities.Order
{
    public class OrderDetail
    {
        public virtual Order Order { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
    
    }
}
