using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.User
{
    public class Contact
    {
        public long Id { get; set; }
        public string ContactName { get; set; }
        public long ForUserId { get; set; }
        public long WithUserId { get; set; }
        public virtual User ForUser { get; set; }
        public virtual User WithUser { get; set; }

    }
}
