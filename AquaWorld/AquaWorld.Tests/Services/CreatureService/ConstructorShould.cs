using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
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
    public class ConstructorShould
    {
        [Test]
        public void InitializeNewInstanceOfICreatureServiceWhenProperParameterIsPassed()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();

            //Act & Assert
            Assert.That(
                () => new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object),
                Is.InstanceOf<ICreatureService>());
        }

        [Test]
        public void ThrowWhenNullParameterIsPassed()
        {
            //Arrange
            IEfAquaWorldDataProvider<Creature> nullDataProvider = null;

            //Act & Assert
            Assert.That(
                () => new AquaWorld.Data.Services.CreatureService(nullDataProvider),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
