using System;
using System.Collections.Generic;

namespace TheNewStringCalculator.Tests
{
    public static class Constants
    {
        public static readonly Dictionary<String, Operator> OperatorsMap = new Dictionary<String, Operator>() 
        {
            { "+", Operator.Add },
            { "-", Operator.Subtract },
            { "*", Operator.Multiply },
            { "/", Operator.Divide }
        };
    }
}
