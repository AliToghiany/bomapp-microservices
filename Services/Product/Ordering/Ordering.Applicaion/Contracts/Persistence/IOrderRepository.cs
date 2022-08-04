
using Ordering.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Applicaion.Contracts.Persistence
{
    public interface IOrderRepository
    {
        Task<Order> AddNewOrder(Order order);
        Task AddOrderDetails(List<OrderDetail> order);
       
    }
}
