using AquaWorld.Data.Models;
using AquaWorld.Data.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaWorld.Tests.Models
{
    [TestFixture]
    public class CreatureModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange & Act
            var actualCreature = new Creature()
            {
                Id = 1,
                Name = "name",
                Description = "desc",
                AvailableCount = 2,
                Category = "fresh",
                ImageUrl = "http://site.com"
            };

            //Assert
            Assert.That(
                () => new Creature(),
                Is.InstanceOf<ICreature>());

            Assert.AreEqual(actualCreature.Id, 1);
            Assert.AreEqual(actualCreature.AvailableCount, 2);
            Assert.AreEqual(actualCreature.Name, "name");
            Assert.AreEqual(actualCreature.Description, "desc");
            Assert.AreEqual(actualCreature.Category, "fresh");
            Assert.AreEqual(actualCreature.ImageUrl, "http://site.com");
        }
    }
}
