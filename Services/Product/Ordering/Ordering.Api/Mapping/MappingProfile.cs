using AutoMapper;
using EventBus.Message.Events;
using Ordering.Applicaion.Features.Orders.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CreateNewOrderCommand, BasketCheckOutEvent>().ReverseMap();
        }
                
    }
}
