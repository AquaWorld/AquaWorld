using AquaWorld.Data.Services;
using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace AquaWorld.Tests.Controllers.AdminController
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnsAnInstanceWhenParameterIsNotNull()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();

            // Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                creatureServiceMock.Object, orderServiceMock.Object);

            // Assert
            Assert.IsNotNull(adminController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AquaWorld.Web.Areas.Admin.AdminController(null, null));
        }

        [Test]
        public void ThrowExceptionWhenCreatureServiceIsNull()
        {
            // Arrange
            CreatureService creatureServiceMock = null;
            var orderServiceMock = new Mock<IOrderService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AquaWorld.Web.Areas.Admin.AdminController(creatureServiceMock, orderServiceMock.Object));
        }

        [Test]
        public void ThrowExceptionWhenOrderServiceIsNull()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            OrderService orderServiceMock = null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AquaWorld.Web.Areas.Admin.AdminController(creatureServiceMock.Object, orderServiceMock));
        }
    }
}
