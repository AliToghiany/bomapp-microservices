using Ordering.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities.Order
{
   public class Order:BaseEntity
   {

        public long UserId { get; set; }
        public long RequestPayId { get; set; }
       
      
    }
}
