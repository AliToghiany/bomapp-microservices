using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.User
{
    public class UserImages
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
    }
}
