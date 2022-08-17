using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Common
{
    public abstract class BaseEntity
    {


        public string CreatedDate { get; set; } = DateTime.Now.ToString();

        public bool IsRemoved { get; set; }

        public string? RemoveDate { get; set; }

        public string? LastModifiedDate { get; set; }

        public bool IsEdited { get; set; }

    }
}
