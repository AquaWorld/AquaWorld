using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AquaWorld.Tests.Services.OrderService
{
    [TestFixture]
    public class CreateOrderShould
    {
        [Test]
        public void CallOrderDataProviderAddAndSaveChangesMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedOrderToCreate = new Order();
            var mockedCreature = new Creature() { Id = 2, Price = 5m, AvailableCount = 1 };

            mockedCreatureDataProvider.Setup(x => x.GetById(2)).Returns(mockedCreature);

            //Act
            var actualOrderService = new AquaWorld.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedCreatureDataProvider.Object,
                mockedOrderToCreate);

            actualOrderService.CreateOrder("Ak47", new List<Creature>() { mockedCreature });

            //Assert
            mockedOrderDataProvider.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
            mockedOrderDataProvider.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void ReturnFalseWhenAvailableCountIsZero()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedOrderToCreate = new Order();
            var mockedCreature = new Creature() { Id = 2, Price = 5m, AvailableCount = 0 };

            mockedCreatureDataProvider.Setup(x => x.GetById(2)).Returns(mockedCreature);

            //Act
            var actualOrderService = new AquaWorld.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedCreatureDataProvider.Object,
                mockedOrderToCreate);

            var result =
                actualOrderService.CreateOrder("Ak47", new List<Creature>() { mockedCreature });

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}