using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.Commodities.Categories
{
    public class Category:IAggregateRoot
    {
    public CategoryId Id { get; private set; }
    public string CategoryName { get;  set; }
    public CategoryId ParentCategoryId { get; set; }
    public List<Commodity> Commodities { get; set; }
    public List<Category> ChildCategories { get; set; }


    }
}
