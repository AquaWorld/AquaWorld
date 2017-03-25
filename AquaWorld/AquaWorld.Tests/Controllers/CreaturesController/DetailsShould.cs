using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.CreaturesController
{
    [TestFixture]
    public class DetailsShould
    {
        [Test]
        public void ReturnViewWithCorrectModelWhenParameterIdIsNotNull()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            Creature firstCreature = new Creature() { Name = "GoldFish", Id = 1 };
            Creature secondCreature = new Creature() { Name = "ClownFish", Id = 2 };
            var listOfCreatures = new List<Creature>() { firstCreature, secondCreature };

            creatureServiceMock.Setup(x => x.GetCreatureById(1)).Returns(firstCreature);

            // Act
            var creatureController = new AquaWorld.Web.Controllers.CreaturesController(creatureServiceMock.Object);

            //Assert
            creatureController
                .WithCallTo(c => c.Details(1))
                .ShouldRenderDefaultView()
                .WithModel<Creature>(model =>
                {
                    Assert.IsInstanceOf(typeof(Creature), model);
                    Assert.AreEqual(model.Name, firstCreature.Name);
                });
        }

        [Test]
        public void ReturnViewWithFirstModelInProvidedCollectionWhenParameterIdIsNull()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            Creature firstCreature = new Creature() { Name = "GoldFish", Id = 1 };
            Creature secondCreature = new Creature() { Name = "ClownFish", Id = 2 };
            var listOfCreatures = new List<Creature>() { firstCreature, secondCreature };

            creatureServiceMock.Setup(x => x.GetAllCreatures()).Returns(listOfCreatures.AsQueryable);

            // Act
            var creatureController = new AquaWorld.Web.Controllers.CreaturesController(creatureServiceMock.Object);

            //Assert
            creatureController
                .WithCallTo(c => c.Details(null))
                .ShouldRenderDefaultView()
                .WithModel<Creature>(model =>
                {
                    Assert.IsInstanceOf(typeof(Creature), model);
                    Assert.AreEqual(model, firstCreature);
                });
        }
    }
}
