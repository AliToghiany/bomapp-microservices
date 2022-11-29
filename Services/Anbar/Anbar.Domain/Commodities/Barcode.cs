using Anbar.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.Commodities
{
    public class Barcode:ValueObject
    {
        public string Value { get; }

        public Barcode(string value)
        {
            CheckRule(new BarcodeValueMustMatchRegex(value));
            Value = value;
        }
    }
}
