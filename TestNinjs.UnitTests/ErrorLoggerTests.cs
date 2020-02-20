

using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjs.UnitTests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowNullArgException(string error)
        {
            var logger = new ErrorLogger();

            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }
    }
}
