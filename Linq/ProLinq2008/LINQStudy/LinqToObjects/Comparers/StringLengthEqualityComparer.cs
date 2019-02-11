using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy.LinqToObjects.Comparers
{
    public class StringLengthEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Length == y.Length;
        }

        public int GetHashCode(string obj)
        {
            return obj.Length;
        }
    }
}
