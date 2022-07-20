using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public class ResultDto
    {
        public bool IsSucsses { get; set; }
        public string Message { get; set; }
    }
    public class ResultDto<T>
    {
        public bool IsSucsses { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
