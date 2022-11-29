using Anbar.Domain.Commodities.Categories;
using Anbar.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.Commodities
{
    public class Commodity:BaseEntity
    {
        public CommodityId Id { get; private set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public Barcode Barcode { get; set; }
        public string Serial { get; set; }
        public CategoryId CategoryId { get; set; }
        public Location Location { get; set; }
        public Commodity()
        {

        }

    }
}
