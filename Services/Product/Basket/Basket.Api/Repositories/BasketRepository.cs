using Basket.Api.Entities;
using Basket.Api.Repositories.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;
        public BasketRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache?? throw new ArgumentNullException(nameof(distributedCache));
        }
        public async Task DeleteBasket(string UserId)
        {

            await _distributedCache.RemoveAsync(UserId);
        }

        public async Task<Cart> GetBasket(string UserId)
        {
            var basket = await _distributedCache.GetStringAsync(UserId);
            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonSerializer.Deserialize<Cart>(basket);
        }

        public async Task<Cart> UpdateBasket(Cart basket)
        {
            await _distributedCache.SetStringAsync(basket.UserId, JsonSerializer.Serialize(basket));

            return await GetBasket(basket.UserId);
        }
    }
}
