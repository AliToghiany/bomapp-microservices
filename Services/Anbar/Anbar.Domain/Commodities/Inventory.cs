using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anbar.Domain.SharedKernel;

namespace Anbar.Domain.Commodities
{
    public class Inventory
    {
        public InventoryValue InventoryValue { get; private set; }
        public Inventory()
        {

        }
        public Inventory(int value,string unit)
        {
            InventoryValue = new InventoryValue(value,unit);
        }
    }
}
