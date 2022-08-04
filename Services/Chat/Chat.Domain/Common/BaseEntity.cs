using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Common
{
    public abstract  class BaseEntity
    {
      
       
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public bool IsRemoved { get; set; }
            public DateTime? RemoveDate { get; set; }
            public DateTime? LastModifiedDate { get; set; }
        
    }
}
