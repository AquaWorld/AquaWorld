using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.AdminController
{
    [TestFixture]
    public class AddCreaturePostShould
    {
        [Test]
        public void RedirectToIndexActionResultWhenModelStateIsValid()
        {
            //Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();
            Creature creature = new Creature();

            //Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                  creatureServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.AddCreature(creature))
                .ShouldRedirectTo(x => x.Index);
        }

        [Test]
        public void ReturnDefaultViewWhenModelStateIsNotValid()
        {
            //Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();
            Creature creature = new Creature();

            //Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                  creatureServiceMock.Object, orderServiceMock.Object);

            adminController.ModelState.AddModelError("testError", "error detected");

            //Assert
            adminController
                .WithCallTo(c => c.AddCreature(creature))
                .ShouldRenderDefaultView();
        }
    }
}
