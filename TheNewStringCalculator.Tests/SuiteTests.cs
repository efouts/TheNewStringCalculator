using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
