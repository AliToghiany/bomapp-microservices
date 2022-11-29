using Anbar.Domain.Commodities;
using Anbar.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.SharedKernel
{
    public class InventoryValue : ValueObject
    {
        public int Value { get; }
        public string Unit { get; }
        public InventoryValue(int value, string unit)
        {
            Value = value;
            Unit = unit;
        }
        public static InventoryValue Of(int value, string unit)
        {
            CheckRule(new InventoryValueHasHaveUnitRule(unit, value));
            return new InventoryValue(value, unit);
        }
        public static InventoryValue operator +(InventoryValue valueLeft, InventoryValue valueRight)
        {
            CheckRule(new InventoryLeftUnitEqualsRightUnit(valueLeft, valueRight));
            return new InventoryValue(valueLeft.Value + valueRight.Value, valueLeft.Unit);

        }
        public static InventoryValue operator *(int number, InventoryValue inventoryValueRight)
        {
            return new InventoryValue(number * inventoryValueRight.Value, inventoryValueRight.Unit);
        }
    }
}
