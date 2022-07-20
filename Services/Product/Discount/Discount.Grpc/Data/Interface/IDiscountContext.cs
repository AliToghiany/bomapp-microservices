using Discount.Grpc.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Data.Interface
{
    public interface IDiscountContext
    {
      public  IMongoCollection<Coupon> Coupons { get; }
    }
}
