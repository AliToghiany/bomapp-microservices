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
        public long Id { get; set; }

        public long GroupId { get; set; }

        public long UserId { get; set; }
        public virtual Group Group { get; set; }
        public RoleOfJoin RoleOfJoinSetting { get; set; }
        public bool SendMessage { get; set; }
        public bool SendMedia { get; set; }
        public bool SendSticker { get; set; }
        public bool SendGif { get; set; }

    }
}
