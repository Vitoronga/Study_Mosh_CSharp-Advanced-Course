using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_Advanced.Generics
{
    // where T : IComparable
    // where T : Product
    // where T : struct 
    // where T : class
    // where T : new()
    public class MyUtilities<T> where T : IComparable
    {
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public T Min(T a, T b)
        {
            return a.CompareTo(b) < 0 ? a : b;
        }

        public bool AreEqual(T a, T b)
        {
            return a.CompareTo(b) == 0;
        }
    }
}
