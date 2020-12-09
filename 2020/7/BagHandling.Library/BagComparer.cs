using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BagHandling.Library
{
    public class BagComparer : IEqualityComparer<Bag>
    {

        public bool Equals(Bag x, Bag y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] Bag obj)
        {
            return obj.GetHashCode();
        }
    }
}
