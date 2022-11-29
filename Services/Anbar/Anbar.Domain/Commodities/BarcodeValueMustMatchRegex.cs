using Anbar.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.Commodities
{
    public sealed class BarcodeValueMustMatchRegex : IBusinessRule
    {
        public string Message => "INVALID BAR CODE TEXT";

        private readonly string _value;

        public BarcodeValueMustMatchRegex(string value)
        {
            _value = value;
        }

        public bool IsBroken()
        {

            String alphabet39 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";


            for (int i = 0; i < _value.Length; i++)
            {
                if (alphabet39.IndexOf(_value[i]) == -1 || _value[i] == '*')
                {
                  
                    return true;
                }
            }
            return false;
        }
    }
}
