using AquaWorld.Data.Contracts;
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
    }
}
