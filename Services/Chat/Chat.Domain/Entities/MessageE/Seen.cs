using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.MessageE
{
    public class Seen
    {
      
        public long Id { get; set; }
       
        public long MessageId { get; set; }

        public long UserId { get; set; }
    }
}
