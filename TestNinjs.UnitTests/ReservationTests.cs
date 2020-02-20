using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjs.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservcation = new Reservation();

            //Act
            var result = reservcation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_MadeByUser_ReturnsTrue()
        {
            //Arrange
            var user = new User();
            var reservcation = new Reservation { MadeBy = user };

            //Act
            var result = reservcation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            //Arrange
            var user = new User();
            var reservcation = new Reservation { MadeBy = user };

            //Act
            var result = reservcation.CanBeCancelledBy(new User());

            //Assert
            Assert.IsFalse(result);
        }
    }
}
