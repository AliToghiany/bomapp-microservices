using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.SeedWork
{
    public abstract class BaseEntity:Entity
    {
        public DateTime CreatedTime { get;}= DateTime.Now;
        public DateTime Update { get; set; }
        public bool IsRemoved { get; set; }
    }
}
