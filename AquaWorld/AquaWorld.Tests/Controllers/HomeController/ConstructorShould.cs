using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace AquaWorld.Tests.Controllers.HomeController
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();

            // Act
            var homeController = new AquaWorld.Web.Controllers.HomeController(creatureServiceMock.Object);

            // Assert
            Assert.IsNotNull(homeController);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AquaWorld.Web.Controllers.HomeController(null));
        }
    }
}
