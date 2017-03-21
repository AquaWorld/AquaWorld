using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models.Contracts;
using AquaWorld.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace AquaWorld.Tests.Data.EfAquaWorldDataProvider
{
    [TestFixture]
    public class AllShould
    {
        [Test]
        public void AllShouldReturnEntitiesOfGivenSet()
        {
            // Arrange
            var mockedDbContext = new Mock<IAquaWorldDbContext>();
            var mockedSet = new Mock<DbSet<ICreature>>();

            // Act
            mockedDbContext.Setup(x => x.Set<ICreature>()).Returns(mockedSet.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);

            // Assert
            Assert.NotNull(dataProvider.All());
            Assert.IsInstanceOf(typeof(DbSet<ICreature>), dataProvider.All());
        }
    }
}
