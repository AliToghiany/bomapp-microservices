using AutoMapper;
using Basket.Api.Entities;
using EventBus.Message.Events.BasketCheckOutEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Mapping
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            this.CreateMap<BasketCheckOut, BasketCheckOutEvent>().ReverseMap();
            this.CreateMap<BasketCheckoutDetail, Detail>().ReverseMap();
        }
    }
}
