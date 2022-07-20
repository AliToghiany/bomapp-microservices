using AutoMapper;

using Ordering.Applicaion.Features.Orders.Commands.CreateOrder;

using Ordering.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Applicaion.Mappers
{
  public  class OrderProfile:Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, CreateNewOrderCommand>().ReverseMap();
      
          
        }
    }
}
