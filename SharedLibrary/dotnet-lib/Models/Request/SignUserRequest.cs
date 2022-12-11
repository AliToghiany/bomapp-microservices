using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Models.Request
{
   
    public class SignUserRequest
    {
        public Guid ConfirmId { get; set; }
        public string Code { get; set; }
    }
}
