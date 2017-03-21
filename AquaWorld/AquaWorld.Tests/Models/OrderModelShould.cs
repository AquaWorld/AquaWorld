using AquaWorld.Data.Models;
using AquaWorld.Data.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AquaWorld.Tests.Models
{
    [TestFixture]
    public class OrderModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange & Act
            var listOfCreatures = new List<Creature>() { new Creature() };
            var user = new User();

            var actualOrder = new Order()
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

            //Assert
            Assert.That(
                () => new Order(), Is.InstanceOf<IOrder>());

            Assert.AreEqual(actualOrder.Id, 1);
            Assert.AreEqual(actualOrder.OrderedOn, DateTime.Parse("03/22/2030"));
            Assert.AreEqual(actualOrder.TotalPrice, 123.5m);
            Assert.AreEqual(actualOrder.ItemsCount, 2);
            Assert.AreEqual(actualOrder.UserId, "4");
            Assert.AreEqual(actualOrder.Creatures, listOfCreatures);
            Assert.AreEqual(actualOrder.User, user);
            Assert.AreEqual(actualOrder.isProceeded, false);
        }
    }
}
