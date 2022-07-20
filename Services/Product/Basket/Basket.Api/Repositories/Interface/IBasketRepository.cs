using Basket.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Repositories.Interface
{
    public interface IBasketRepository
    {
        Task<Cart> GetBasket(string userId);
        Task<Cart> UpdateBasket(Cart basket);
        Task DeleteBasket(string userId);
    }
}
