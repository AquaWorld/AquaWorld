using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using AquaWorld.Tests.Helpers;
using NUnit.Framework;

namespace AquaWorld.Tests.Data.AquaWorldDbContext
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange & Act
            var context = new AquaWorld.Data.AquaWorldDbContext();

            // Assert
            Assert.IsInstanceOf<AquaWorld.Data.AquaWorldDbContext>(context);
        }

        [Test]
        public void Return_InstanceOfIPetsWonderlandDbContext()
        {
            // Arrange & Act
            var context = new AquaWorld.Data.AquaWorldDbContext();

            // Assert
            Assert.IsInstanceOf<IAquaWorldDbContext>(context);
        }

        [Test]
        public void SetCreaturesDbSetAndOrdersDbSet()
        {
            // Arrange
            var context = new AquaWorld.Data.AquaWorldDbContext();
            var creatures = new DbSetForTest<Creature>();
            var orders = new DbSetForTest<Order>();

            //Act
            context.Creatures = creatures;
            context.Orders = orders;

            //Assert
            Assert.AreEqual(context.Creatures, creatures);
            Assert.AreEqual(context.Orders, orders);
        }
    }
}
