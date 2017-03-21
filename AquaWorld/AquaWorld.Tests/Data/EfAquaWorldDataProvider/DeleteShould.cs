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
    public class DeleteShould
    {
        [Test]
        public void ThrowNullReferenceExceptionWhenPassedArgumentIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<IAquaWorldDbContext>();
            var mockedSet = new Mock<DbSet<ICreature>>();

            // Act
            mockedDbContext.Setup(set => set.Set<ICreature>()).Returns(mockedSet.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);
            ICreature entity = null;

            // Assert
            Assert.That(() => dataProvider.Delete(entity),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void NotThrowExceptionWhenPassedArgumentIsValid()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<ICreature>>();
            var mockedAdvert = new Mock<ICreature>();
            mockedSet.SetupAllProperties();
            var mockedDbContext = new Mock<IAquaWorldDbContext>();

            // Act
            mockedDbContext.Setup(x => x.Set<ICreature>()).Returns(mockedSet.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);

            try
            {
                dataProvider.Delete(mockedAdvert.Object);
            }
            catch (NullReferenceException e)
            {
            }

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}
