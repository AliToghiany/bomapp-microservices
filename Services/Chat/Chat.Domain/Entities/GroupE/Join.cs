using Chat.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.GroupE
{
    public class Join:BaseEntity
    {
        [Key]
        public string Id { get; set; }

        public string GroupId { get; set; }

        public long UserId { get; set; }

    }
}
