using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Entities
{
    public class Category:BaseEntity
    {
     
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

    }
}
