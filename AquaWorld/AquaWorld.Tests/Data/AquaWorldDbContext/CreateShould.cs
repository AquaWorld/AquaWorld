using AquaWorld.Data.Contracts;
using NUnit.Framework;

namespace AquaWorld.Tests.Data.AquaWorldDbContext
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void ReturnNewDbContextInstance()
        {
            // Arrange & Act
            var newContext = AquaWorld.Data.AquaWorldDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<IAquaWorldDbContext>(newContext);
        }
    }
}
