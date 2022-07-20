using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Entities
{
    public class BasketCheckOut
    {
        public long UserId { get; set; }
        public long RequestPayId { get; set; }
        public List<BasketCheckoutDetail> Details { get; set; }
    }
}
