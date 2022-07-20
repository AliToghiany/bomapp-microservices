using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Applicaion.Features.Orders.Commands.CreateOrder
{
    public class CreateNewOrderCommand:IRequest<long>
    {

        public long RequestPayId { get; set; }
        public long UserId { get; set; }
        public List<NewOrderDetail> Details { get; set; }

    }
}
