using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AquaWorld.Tests.Services.OrderService
{
    [TestFixture]
    public class GetAllOrdersShould
    {
        [Test]
        public void CallOrderDataProviderAllMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedOrderToCreate = new Order();

            mockedOrderDataProvider.Setup(x => x.All()).Returns(new List<Order>().AsQueryable);

            //Act
            var actualOrderService = new AquaWorld.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedCreatureDataProvider.Object,
                mockedOrderToCreate);

            actualOrderService.GetAllOrders();

            //Assert
            mockedOrderDataProvider.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableOrdersCollectionProvidedFromOrderDataProviderAllMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var mockedOrderToCreate = new Order();
            var mockedOrdersCollection = new List<Order>() { mockedOrderToCreate };

            mockedOrderDataProvider.Setup(x => x.All()).Returns(mockedOrdersCollection.AsQueryable);

            //Act
            var actualOrderService = new AquaWorld.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedCreatureDataProvider.Object,
                mockedOrderToCreate);

            var resultOrdersCollection = actualOrderService.GetAllOrders();

            //Assert
            Assert.AreEqual(mockedOrdersCollection, resultOrdersCollection);
            Assert.That(resultOrdersCollection, Is.InstanceOf<IQueryable<Order>>());
        }
    }
}
