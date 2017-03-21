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
    public class DetachShould
    {
        [Test]
        public void BeCalledWhenInvoked()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<ICreature>>();
            var mockedDbContext = new Mock<IAquaWorldDbContext>();
            mockedDbContext.Setup(x => x.Set<ICreature>()).Returns(mockedSet.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);
            var mockedAdvert = new Mock<ICreature>();

            // Act
            try
            {
                dataProvider.Detach(mockedAdvert.Object);
            }
            catch (NullReferenceException ) { };

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}
