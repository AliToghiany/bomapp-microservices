using AutoMapper;
using EventBus.Message.Events.BasketCheckOutEvent;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Applicaion.Features.Orders.Commands.CreateOrder;
using System;
using System.Threading.Tasks;

namespace Ordering.Api.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckOutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(IMapper mapper, IMediator mediator, ILogger<BasketCheckoutConsumer> logger)
        {
            _mapper = mapper;
           _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BasketCheckOutEvent> context)
        {
            var orderCommand =_mapper.Map<CreateNewOrderCommand>(context.Message);
            var result = await _mediator.Send(orderCommand);
            _logger.LogInformation($"BasketCheckOut consumed sucssfuly.order has been created with id:{result}");
        }
    }
}