using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models.Contracts;
using AquaWorld.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace AquaWorld.Tests.Data.EfAquaWorldDataProvider
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionIfDbContextPassedIsNull()
        {
            // Arrange
            IAquaWorldDbContext nullContext = null;

            // Act & Assert
            Assert.That(() => new EfAquaWorldDataProvider<ICreature>(nullContext),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void WorkCorrectlyIfDbContextPassedIsValid()
        {
            // Arrange
            var mockedDbContext = new Mock<IAquaWorldDbContext>();
            var mockedModel = new Mock<DbSet<ICreature>>();

            // Act
            mockedDbContext.Setup(x => x.Set<ICreature>()).Returns(mockedModel.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);

            // Assert
            Assert.That(dataProvider, Is.Not.Null);
        }

        [Test]
        public void SetContextCorrectlyWhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IAquaWorldDbContext>();
            var mockedModel = new Mock<DbSet<ICreature>>();

            // Act
            mockedContext.Setup(x => x.Set<ICreature>()).Returns(mockedModel.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedContext.Object);

            // Assert
            Assert.That(dataProvider.Context, Is.Not.Null);
            Assert.That(dataProvider.Context, Is.EqualTo(mockedContext.Object));
        }

        [Test]
        public void SetDbSetCorrectlyWhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IAquaWorldDbContext>();
            var mockedModel = new Mock<DbSet<ICreature>>();

            // Act
            mockedContext.Setup(x => x.Set<ICreature>()).Returns(mockedModel.Object);
            var repository = new EfAquaWorldDataProvider<ICreature>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }
    }
}
