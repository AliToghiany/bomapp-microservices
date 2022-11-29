using Anbar.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.SharedKernel
{
    public class InventoryValueHasHaveUnitRule : IBusinessRule
    {
        private readonly string _unit;
        private readonly int _value;

        public InventoryValueHasHaveUnitRule(string unit, int value)
        {
            _unit = unit;
            _value = value;
        }

        public string Message => "Money value must have currency or value must be greater than 0";

        public bool IsBroken()
        {
            return string.IsNullOrEmpty(_unit) || _value < 0;
        }
    }
}
