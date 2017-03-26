using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace AquaWorld.Tests.Controllers.OrderController
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnsAnInstanceWhenParameterIsNotNull()
        {
            // Arrange
            var orderServiceMock = new Mock<IOrderService>();

            // Act
            var orderController = new AquaWorld.Web.Controllers.OrderController(orderServiceMock.Object);

            // Assert
            Assert.IsNotNull(orderController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AquaWorld.Web.Controllers.OrderController(null));
        }
    }
}
