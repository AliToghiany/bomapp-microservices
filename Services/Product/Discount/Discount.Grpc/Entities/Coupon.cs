using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Entities
{
    public class Coupon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProductName { get; set; }
        public long ProductId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
