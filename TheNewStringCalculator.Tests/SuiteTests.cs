using NUnit.Framework;

namespace TheNewStringCalculator.Tests
{
    [TestFixture]
    public class SuiteTests
    {
        [Test]
        public void AssertTheTruth()
        {
            Assert.That(true, Is.True);
        }
    }
}
