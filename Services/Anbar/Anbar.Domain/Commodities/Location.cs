using Anbar.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.Commodities
{
    public class Location:ValueObject
    {
        public string Value { get; private set; }
        public Location(string value)
        {
            Value = value;
        }
    }
}
