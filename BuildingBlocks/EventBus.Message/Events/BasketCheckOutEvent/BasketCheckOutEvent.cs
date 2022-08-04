using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Message.Events.BasketCheckOutEvent
{
    public class BasketCheckOutEvent : IntegrationBaseEvent
    {
        public long UserId { get; set; }
        public long RequestPayId { get; set; }
        public List<Detail> Details { get; set; }
    }
}
