using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Models.Response
{
   
        public class SignUserResponse
        {
            public long UserId { get; set; }
            public bool IsNew { get; set; }
            public string? Token { get; set; }
        }
    
}
