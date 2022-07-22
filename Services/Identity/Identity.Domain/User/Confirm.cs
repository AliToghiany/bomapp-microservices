using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.User
{
    public class Confirm
    {
        public Guid Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime ExpireTime { get; set; } = DateTime.Now.AddMinutes(4);

        public string Code { get; set; }
        public string IP { get; set; }          
        public string Phone { get; set; }
        
    }
}
