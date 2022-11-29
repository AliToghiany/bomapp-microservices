using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string name) : base($"{name}:is bad")
        {
        }
    }
}
