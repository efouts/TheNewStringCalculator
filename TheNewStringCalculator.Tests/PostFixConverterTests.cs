using System;
using NUnit.Framework;

namespace TheNewStringCalculator.Tests
{
    public class PostFixConverterTests
    {
        [TestCase("", "")]
        [TestCase("1", "1")]
        [TestCase("1 + 1", "1 1 +")]
        [TestCase("1 + 1 * 3", "1 1 3 * +")]
        [TestCase("4 - 3", "4 3 -")]
        [TestCase("4 - -3", "4 -3 -")]
        [TestCase("4 / 2 * 1", "4 2 / 1 *")]
        [TestCase("-5 + -3 - -4", "-5 -3 -4 - +")]
        [TestCase("5 * 2 - 4 / 2 + 2", "5 2 * 4 2 / - 2 +")]
        [TestCase("5 * 2 - 3 / 2 + 2", "5 2 * 3 2 / - 2 +")]
        public void AssertConversion(String input, String expectedResult)
        {
            var converter = new PostFixConverter(Constants.OperatorsMap);
            var result = converter.ConvertFromInfix(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
