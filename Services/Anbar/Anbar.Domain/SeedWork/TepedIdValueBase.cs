using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Domain.SeedWork
{
    public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
    {
        public int Value { get;  }
        protected TypedIdValueBase(int value)
        {
            Value = value;
        }
        public bool Equals(TypedIdValueBase? other)
        {
            return this.Value == other.Value;
        }
        public override bool Equals(object? obj)
        {

            if (ReferenceEquals(null, obj)) return false;
            return obj is TypedIdValueBase other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public static bool operator ==(TypedIdValueBase obj1, TypedIdValueBase obj2)
        {
            if (object.Equals(obj1, null))
            {
                if (object.Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }
        public static bool operator !=(TypedIdValueBase x, TypedIdValueBase y)
        {
            return !(x == y);
        }



    }
}
