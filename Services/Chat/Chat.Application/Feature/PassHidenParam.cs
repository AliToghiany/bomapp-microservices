using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Feature
{
    public class PassHidenParam<T>
    {
        private T Data;
        public void SetData(T newData)
        {
            Data = newData ?? throw new ArgumentException();
        }
        public T ReturnData()
        {
           return Data;
        }

    }
}
