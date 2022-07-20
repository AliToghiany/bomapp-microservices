using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Entities
{
    public class BasketCheckoutDetail
    {
        public long ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
