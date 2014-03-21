using System;
using System.Collections.Generic;

namespace TheNewStringCalculator
{
    public class OperatorComparer : Comparer<Operator>
    {
        public override Int32 Compare(Operator a, Operator b)
        {
            var precedenceA = Convert.ToInt32(a);
            var precedenceB = Convert.ToInt32(b);

            return precedenceA.CompareTo(precedenceB);
        }
    }
}
