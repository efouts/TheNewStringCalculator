using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TheNewStringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator(new ExpressionParser());
        }

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1+1", 2)]
        [TestCase("2-1", 1)]
        [TestCase("2*1", 2)]
        [TestCase("4/2", 2)]
        [TestCase("2--1", 3)]
        [TestCase("-5+-3--4", -4)]
        [TestCase("5*2-4/2+2", 10)]
        public void AssertCalculation(String input, Int32 expectedResult)
        {
            var result = calculator.Calculate(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
