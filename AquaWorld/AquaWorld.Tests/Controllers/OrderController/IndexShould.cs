using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.OrderController
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnView()
        {
            // Arrange
            var orderServiceMock = new Mock<IOrderService>();

            // Act
            var creatureController = new AquaWorld.Web.Controllers.OrderController(orderServiceMock.Object);

            //Assert
            creatureController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
