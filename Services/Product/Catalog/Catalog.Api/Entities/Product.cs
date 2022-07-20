using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Entities
{
    public class Product:BaseEntity
    {
       
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }
        public virtual long CategoryId { get; set; }
    }
}
