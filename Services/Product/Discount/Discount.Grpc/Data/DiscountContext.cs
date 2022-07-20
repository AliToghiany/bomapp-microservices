using Discount.Grpc.Data.Interface;
using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Data
{
    public class DiscountContext: IDiscountContext
    {
        public DiscountContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Coupons = database.GetCollection<Coupon>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
     
        }

       public IMongoCollection<Coupon> Coupons { get; }
    }
}
