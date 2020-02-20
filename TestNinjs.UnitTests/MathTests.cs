using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinjs.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        //[Ignore("Bacause")]
        public void Add_WhenCalled_ResturnSum()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void Add_WhenCalled_ResturnTheGreaterArg(int a, int b, int expected)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbers()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result.Count(), Does.Contain(1));
            //Assert.That(result.Count(), Does.Contain(3));
            //Assert.That(result.Count(), Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }
    }
}
