using Discount.Grpc.Data.Interface;
using Discount.Grpc.Entities;
using Discount.Grpc.Repositories.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public class DiscountRipository : IDiscountRipository
    {
        private readonly IDiscountContext _discountContext;
        public DiscountRipository(IDiscountContext discountContext)
        {
            _discountContext = discountContext??throw new ArgumentNullException(nameof(discountContext));
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            try
            {
                await _discountContext.Coupons.InsertOneAsync(coupon);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public async Task<bool> DeleteDiscount(long productId)
        {
           
            
                FilterDefinition<Coupon> filter = Builders<Coupon>.Filter.Eq(p => p.ProductId, productId);
                DeleteResult deleteResult= await _discountContext.Coupons.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Coupon> GetDiscount(long productId)
        {
            return await(await _discountContext.Coupons.FindAsync(p => p.ProductId == productId)).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var updateResult = await _discountContext
                                      .Coupons
                                       .ReplaceOneAsync(filter: g => g.Id == coupon.Id, replacement: coupon);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
