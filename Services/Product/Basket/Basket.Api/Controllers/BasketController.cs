using AutoMapper;
using Basket.Api.Entities;
using Basket.Api.Repositories.Interface;
using EventBus.Message.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketRepository _repository;
        //private readonly DiscountGrpcService _discountGrpcService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint/*, DiscountGrpcService discountGrpcService, , */)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            //_discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
           _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("{userId}", Name = "GetBasket")]
        [ProducesResponseType(typeof(Cart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Cart>> GetBasket(string userId)
        {
            var basket =await _repository.GetBasket(userId);
            return Ok(basket??new Cart(userId));
        }
        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();
        }
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckOut basketCheckOut)
        {
            var basket = await _repository.GetBasket(basketCheckOut.UserId.ToString());
            if (basketCheckOut==null)
            {
                return BadRequest();
            }
            var eventMessage = _mapper.Map<BasketCheckOutEvent>(basketCheckOut);
          
            await _publishEndpoint.Publish(eventMessage);
            await _repository.DeleteBasket(basketCheckOut.UserId.ToString());
            return Accepted();
        }
    }
}
