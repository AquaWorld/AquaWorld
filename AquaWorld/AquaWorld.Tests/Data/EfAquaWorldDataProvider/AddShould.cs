using AquaWorld.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;
using AquaWorld.Data.Models.Contracts;
using AquaWorld.Data.Repositories;

namespace AquaWorld.Tests.Data.EfAquaWorldDataProvider
{
    [TestFixture]
    public class AddShould
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
            Assert.That(() => dataProvider.Add(entity),
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
            var fakeEntry = (DbEntityEntry<ICreature>)FormatterServices.GetSafeUninitializedObject(typeof(DbEntityEntry<ICreature>));

            // Act
            mockedDbContext.Setup(x => x.Set<ICreature>()).Returns(mockedSet.Object);
            mockedDbContext.Setup(x => x.Entry(It.IsAny<ICreature>())).Returns(fakeEntry);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);

            try
            {
                dataProvider.Add(mockedAdvert.Object);
            }
            catch (NullReferenceException)
            {
            }

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}
