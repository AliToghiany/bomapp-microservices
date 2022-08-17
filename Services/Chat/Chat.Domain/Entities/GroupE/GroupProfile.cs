﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities.GroupE
{
    public class GroupProfile
    {
        [Key]
        public string Id { get; set; }
      
        public string Path { get; set; }
   
        public string Name { get; set; }

        public string GroupeId { get; set; }
    }
}
