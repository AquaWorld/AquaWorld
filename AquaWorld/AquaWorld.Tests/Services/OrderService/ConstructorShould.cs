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

namespace AquaWorld.Tests.Services.OrderService
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitializeNewInstanceOfIOrderServiceWhenProperParameterIsPassed()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedOrderToCreate = new Mock<Order>();

            //Act & Assert
            Assert.That(
                () => new AquaWorld.Data.Services.OrderService(
                    mockedOrderDataProvider.Object,
                    mockedCreatureDataProvider.Object,
                    mockedOrderToCreate.Object),
                Is.InstanceOf<IOrderService>());
        }
    }
}
