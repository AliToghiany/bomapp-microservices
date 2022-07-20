using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Entities
{
    public class Image
    {
        public long Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
    }
}
