using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.User
{
    public class User: IdentityUser<long>
    {
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; }
         public DateTime RemoveTime { get; set; }
          public bool IsActive { get; set; }
          public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
    }
}
