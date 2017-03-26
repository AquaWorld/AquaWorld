using AquaWorld.Data.Models;
using AquaWorld.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AquaWorld.Tests.ViewModels
{
    [TestFixture]
    public class OrderViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var listOfCreatures = new List<Creature>() { new Creature() };
            var user = new User();

            var order = new Order()
            {
                Id = 1,
                OrderedOn = DateTime.Parse("03/22/2030"),
                TotalPrice = 123.5m,
                ItemsCount = 2,
                UserId = "4",
                User = user,
                Creatures = listOfCreatures,
                isProceeded = false
            };

            //Act
            var orderViewModel = new OrderViewModel(order);

            //Assert

            Assert.AreEqual(order.OrderedOn, orderViewModel.OrderedOn);
            Assert.AreEqual(order.TotalPrice, orderViewModel.TotalPrice);
            Assert.AreEqual(order.ItemsCount, orderViewModel.ItemsCount);
            Assert.AreEqual(order.UserId, orderViewModel.UserId);
            Assert.AreEqual(order.Creatures, orderViewModel.Creatures);
            Assert.AreEqual(order.User, orderViewModel.User);
            Assert.AreEqual(order.isProceeded, orderViewModel.isProceeded);
        }
    }
}
