using AquaWorld.Data.Models;
using AquaWorld.Web.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace AquaWorld.Tests.ViewModels
{
    [TestFixture]
    public class CreatureViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var creature = new Creature()
            {
                Id = 1,
                Name = "name",
                Description = "desc",
                AvailableCount = 2,
                Category = "fresh",
                ImageUrl = "http://site.com",
                Price = 12.5m,
                Orders = new List<Order>() { new Order()}
            };

            //Act
            var creatureViewModel = new CreatureViewModel(creature);

            //Assert
            Assert.AreEqual(creature.Id, creatureViewModel.Id);
            Assert.AreEqual(creature.AvailableCount, creatureViewModel.AvailableCount);
            Assert.AreEqual(creature.Price, creatureViewModel.Price);
            Assert.AreEqual(creature.Name, creatureViewModel.Name);
            Assert.AreEqual(creature.Description, creatureViewModel.Description);
            Assert.AreEqual(creature.Category, creatureViewModel.Category);
            Assert.AreEqual(creature.ImageUrl, creatureViewModel.ImageUrl);
            Assert.AreEqual(creature.OrderedItemsCount, creatureViewModel.OrderedItemsCount);
            Assert.AreEqual(creature.Orders, creatureViewModel.Orders);
        }
    }
}
