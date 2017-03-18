using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using Moq;
using NUnit.Framework;
using System;

namespace AquaWorld.Tests.Services.CreatureService
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void CallCreatureDataProviderAddMethodWithSameRecievedCreature()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedCreature = new Mock<Creature>();

            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            actualCreatureService.Create(mockedCreature.Object);

            //Assert
            mockedDataProvider.Verify(
                service => service.Add(mockedCreature.Object),
                Times.Once);
        }

        [Test]
        public void CallCreatureDataProviderSaveChangesMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedCreature = new Mock<Creature>();

            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            actualCreatureService.Create(mockedCreature.Object);

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
                () => actualCreatureService.Create(nullCreature),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
