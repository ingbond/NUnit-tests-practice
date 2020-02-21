using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_InvalidSpeed_ThrowArgumentOutOfRangeException(int speed)
        {
            var demerit = new DemeritPointsCalculator();

            Assert.That(() => demerit.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        
        [Test]
        [TestCase(0, 0)]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(66,0)]
        [TestCase(70,1)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoint(int speed, int expected)
        {
            var demerit = new DemeritPointsCalculator();

            Assert.That(() => demerit.CalculateDemeritPoints(speed), Is.EqualTo(expected));
        }
    }
}
