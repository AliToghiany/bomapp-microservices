using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Entities
{
    public class BaseEntity
    {
        public long Id { get; protected set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsRemoved { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
