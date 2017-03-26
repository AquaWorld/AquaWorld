using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.ShoppingCartController
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnView()
        {

            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();

            // Act
            var shoppingCartController = new AquaWorld.Web.Controllers.ShoppingCartController(creatureServiceMock.Object);

            //Assert
            shoppingCartController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
