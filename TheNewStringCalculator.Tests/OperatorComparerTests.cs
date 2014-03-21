using System;
using NUnit.Framework;

namespace TheNewStringCalculator.Tests
{
    [TestFixture]
    public class OperatorComparerTests
    {
        [TestCase(Operator.Add, Operator.Add, 0)]
        [TestCase(Operator.Add, Operator.Subtract, -1)]
        [TestCase(Operator.Subtract, Operator.Add, 1)]
        public void Compare(Operator a, Operator b, Int32 result)
        {
            Assert.That(a.CompareTo(b), Is.EqualTo(result));
        }
    }
}
