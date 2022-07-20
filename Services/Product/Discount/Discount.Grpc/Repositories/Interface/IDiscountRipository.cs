using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories.Interface
{
    public interface IDiscountRipository
    {
        Task<Coupon> GetDiscount(long productId);

        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(long productId);
    }
}
