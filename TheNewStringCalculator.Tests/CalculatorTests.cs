using System;
using NUnit.Framework;

namespace TheNewStringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private InfixCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new InfixCalculator(Constants.OperatorsMap);
        }

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1 + 1", 2)]
        [TestCase("1 + 1 * 3", 4)]
        [TestCase("4 - 3", 1)]
        [TestCase("4 - -3", 7)]
        [TestCase("4 / 2 * 1", 2)]
        [TestCase("-5 + -3 - -4", -4)]
        [TestCase("5 * 2 - 4 / 2 + 2", 10)]
        [TestCase("5 * 2 - 3 / 2 + 2", 10.5)]
        public void AssertCalculation(String input, Double expectedResult)
        {
            Assert.That(calculator.Calculate(input), Is.EqualTo(expectedResult));
        }
    }
}
