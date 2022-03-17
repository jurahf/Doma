using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class IdEqualityComparer : IEqualityComparer<IViewModel>
    {
        public bool Equals(IViewModel x, IViewModel y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(IViewModel obj)
        {
            return obj.Id;
        }
    }
}
