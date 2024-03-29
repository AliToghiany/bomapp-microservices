﻿using Chat.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.GroupE
{
    public class GroupBanUser:BaseEntity
    {
       
        public long Id { get; set; }

        public virtual Group Group { get; set; }
        public long GroupId { get; set; }
    
        public long UserId { get; set; }

    }
}
