using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Applicaion.Contracts.Persistence;
using Ordering.Domain.Entities.Order;

namespace Ordering.Applicaion.Features.Orders.Commands.CreateOrder
{
    public class CreateNewOrderCommandHandler : IRequestHandler<CreateNewOrderCommand,long>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
    
        private readonly ILogger<CreateNewOrderCommandHandler> _logger;

        public CreateNewOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper, ILogger<CreateNewOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<long> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
           
         
            var newOrder= await _orderRepository.AddNewOrder(order);
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in request.Details)
            {
                orderDetails.Add(new OrderDetail
                {
                    OrderId=newOrder.Id,
                    Price=item.Price,
                    ProductId=item.ProductId
                });
            }
            await _orderRepository.AddOrderDetails(orderDetails);
            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");
            await SendMessageForBuyer(order);
            return newOrder.Id;

        }
        public async Task SendMessageForBuyer(Order order)
        {

        }
    }
}
