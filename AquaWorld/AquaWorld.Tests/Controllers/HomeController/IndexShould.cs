using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.HomeController
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnViewWithListOfCorrectModelsWhenThereAreAnyExisting()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            Creature firstCreature = new Creature() { Name = "GoldFish" };
            Creature secondCreature = new Creature() { Name = "ClownFish" };

            var listOfCreatures = new List<Creature>() { firstCreature, secondCreature };

            // Act
            var homeController = new AquaWorld.Web.Controllers.HomeController(creatureServiceMock.Object);

            //Assert
            homeController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<IQueryable<Creature>>(model =>
                  {
                      Assert.IsInstanceOf(typeof(IQueryable<Creature>), model);
                  });
        }
    }
}
