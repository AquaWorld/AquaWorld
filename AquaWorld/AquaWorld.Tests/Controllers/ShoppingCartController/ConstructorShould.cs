using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace AquaWorld.Tests.Controllers.ShoppingCartController
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnsAnInstanceWhenParameterIsNotNull()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();

            // Act
            var shoppingCartController = new AquaWorld.Web.Controllers.ShoppingCartController(creatureServiceMock.Object);

            // Assert
            Assert.IsNotNull(shoppingCartController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AquaWorld.Web.Controllers.ShoppingCartController(null));
        }
    }
}
