using Ordering.Applicaion.Contracts.Persistence;
using Ordering.Domain.Entities.Order;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Ordering.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;
        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public Task<Order> AddNewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task AddOrderDetails(List<OrderDetail> order)
        {
            throw new NotImplementedException();
        }

       
       
    }
   
}
