using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Message.Events
{
   public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id =Guid.NewGuid();
            CrationDate = DateTime.UtcNow;
        }
        public IntegrationBaseEvent(Guid id,DateTime crationDate)
        {
            Id = id;
            CrationDate = crationDate;

        }
        public Guid Id { get; private set; }
        public DateTime CrationDate { get; set; }
    }
}
