using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(2, "2")]
        public void GetOutput_WhenCalled_ShouldReturnFizzOrBuzz(int number, string expected)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
