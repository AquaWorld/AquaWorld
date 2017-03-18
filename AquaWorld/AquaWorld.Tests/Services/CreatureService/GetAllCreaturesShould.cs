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
    public class GetAllCreaturesShould
    {
        [Test]
        public void CallCreatureDataProviderAllMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();

            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            actualCreatureService.GetAllCreatures();

            //Assert
            mockedDataProvider.Verify(
                service => service.All(),
                Times.Once);
        }

        [Test]
        public void ReturnIqueryableCollectionFromCreatureDataProviderAllMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();

            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            var actualResult = actualCreatureService.GetAllCreatures();

            //Assert
            Assert.That(actualResult, Is.Not.Null.And.InstanceOf<IQueryable<Creature>>());
        }
    }
}
