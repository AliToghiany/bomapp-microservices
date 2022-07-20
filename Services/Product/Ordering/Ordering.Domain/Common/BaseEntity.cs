using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public string LastModifiedBy { get; set; }
        public DateTime? RemoveTime { get; set; }
    }
}
