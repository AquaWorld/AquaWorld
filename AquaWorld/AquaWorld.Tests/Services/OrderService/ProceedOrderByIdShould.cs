using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
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
    public class ProceedOrderByIdShould
    {
        [Test]
        public void CallOrderDataProviderGetByIdMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var orderId = 5;
            var mockedOrderToUpdate = new Order() { Id = orderId };


            mockedOrderDataProvider.Setup(x => x.GetById(orderId)).Returns(mockedOrderToUpdate);

            //Act
            var actualOrderService = new AquaWorld.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedCreatureDataProvider.Object,
                mockedOrderToUpdate);

            actualOrderService.ProceedOrderById(orderId);

            //Assert
            mockedOrderDataProvider.Verify(x => x.GetById(orderId), Times.Once);
        }

        [Test]
        public void CallOrderDataProviderSaveChangesMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var orderId = 5;
            var mockedOrderToUpdate = new Order() { Id = orderId };


            mockedOrderDataProvider.Setup(x => x.GetById(orderId)).Returns(mockedOrderToUpdate);

            //Act
            var actualOrderService = new AquaWorld.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedCreatureDataProvider.Object,
                mockedOrderToUpdate);

            actualOrderService.ProceedOrderById(orderId);

            //Assert
            mockedOrderDataProvider.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void SetOrderToUpdateIsProceededValueToTrue()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfAquaWorldDataProvider<Order>>();
            var mockedCreatureDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();
            var orderId = 5;
            var mockedOrderToUpdate = new Order() { Id = orderId, isProceeded = false };


            mockedOrderDataProvider.Setup(x => x.GetById(orderId)).Returns(mockedOrderToUpdate);

            //Act
            var actualOrderService = new AquaWorld.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedCreatureDataProvider.Object,
                mockedOrderToUpdate);

            actualOrderService.ProceedOrderById(orderId);

            //Assert
            Assert.AreEqual(mockedOrderToUpdate.isProceeded, true);
        }
    }
}
