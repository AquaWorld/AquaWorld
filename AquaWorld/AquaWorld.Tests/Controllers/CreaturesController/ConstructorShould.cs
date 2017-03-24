using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace AquaWorld.Tests.Controllers.CreaturesController
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
            var creaturesController = new AquaWorld.Web.Controllers.CreaturesController(creatureServiceMock.Object);

            // Assert
            Assert.IsNotNull(creaturesController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AquaWorld.Web.Controllers.CreaturesController(null));
        }
    }
}
