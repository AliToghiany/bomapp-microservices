using Anbar.Domain.SeedWork;
using Anbar.Domain.SharedKernel;

namespace Anbar.Domain
{
    internal class InventoryLeftUnitEqualsRightUnit : IBusinessRule
    {
        private readonly InventoryValue _valueLeft;
        private readonly InventoryValue _valueRight;

        public InventoryLeftUnitEqualsRightUnit(InventoryValue valueLeft, InventoryValue valueRight)
        {
            this._valueLeft = valueLeft;
            this._valueRight = valueRight;
        }

        public string Message => "Inventory value units must be the same";

        public bool IsBroken()
        {
            return _valueLeft.Unit == _valueRight.Unit;
        }
    }
}