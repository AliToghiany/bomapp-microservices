using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.MessageE
{
    public class File
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }
       
        public string Path { get; set; }
  
        public string Name { get; set; }

        public string MessageId { get; set; }
    }
}
