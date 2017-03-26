using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaWorld.Tests.Services.CreatureService
{
    [TestFixture]
    public class UpdateCreatureShould
    {
        [Test]
        public void CallCreatureDataProviderUpdateMethodWithSameRecievedCreature()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedCreature = new Creature() { Id = 1 };

            mockedDataProvider.Setup(x => x.GetById(1)).Returns(mockedCreature);

            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            actualCreatureService.UpdateCreature(mockedCreature);

            //Assert
            mockedDataProvider.Verify(
                service => service.Update(mockedCreature),
                Times.Once);
        }

        [Test]
        public void CallCreatureDataProviderSaveChangesMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedCreature = new Creature() { Id = 1 };

            mockedDataProvider.Setup(x => x.GetById(1)).Returns(mockedCreature);
            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            actualCreatureService.UpdateCreature(mockedCreature);

            //Assert
            mockedDataProvider.Verify(
                service => service.SaveChanges(),
                Times.Once);
        }

        [Test]
        public void ThrowWhenArgumentCreatureHasNullValue()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            Creature nullCreature = null;

            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            //Assert
            Assert.That(
                () => actualCreatureService.UpdateCreature(nullCreature),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
