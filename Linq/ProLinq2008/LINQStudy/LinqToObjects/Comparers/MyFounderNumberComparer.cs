using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.LinqToObjects
{
    public class MyFounderNumberComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return (isFounder(x) == isFounder(y));
        }
        public int GetHashCode(int i)
        {
            int f = 1;
            int nf = 100;
            return (isFounder(i) ? f.GetHashCode() : nf.GetHashCode());
        }
        public bool isFounder(int id)
        {
            return (id < 100);
        }
    }
}
