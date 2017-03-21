using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models.Contracts;
using AquaWorld.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace AquaWorld.Tests.Data.EfAquaWorldDataProvider
{
    [TestFixture]
    public class DisposeShould
    {

        [Test]
        public void BeCalledWhenDisposingProvider()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<ICreature>>();
            var mockedDbContext = new Mock<IAquaWorldDbContext>();
            mockedDbContext.Setup(x => x.Set<ICreature>()).Returns(mockedSet.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);

            // Act
            dataProvider.Dispose();

            // Assert
            mockedDbContext.Verify(x => x.Dispose(), Times.Once);
        }
    }
}
