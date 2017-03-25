using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.CreaturesController
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
            var creatureController = new AquaWorld.Web.Controllers.CreaturesController(creatureServiceMock.Object);

            //Assert
            creatureController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<IList<Creature>>(model =>
                {
                    Assert.IsInstanceOf(typeof(IList<Creature>), model);
                });
        }
    }
}
