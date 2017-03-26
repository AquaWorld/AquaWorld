using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.AdminController
{
    [TestFixture]
    public class AddCreatureShould
    {
        [Test]
        public void ReturnView()
        {
            //Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();

            //Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                  creatureServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.AddCreature())
                .ShouldRenderDefaultView();
        }
    }
}
