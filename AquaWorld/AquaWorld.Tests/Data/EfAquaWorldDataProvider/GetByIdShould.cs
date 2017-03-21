using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models.Contracts;
using AquaWorld.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace AquaWorld.Tests.Data.EfAquaWorldDataProvider
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void ReturnCorrectResultWhenParameterIsValid()
        {
            // Arrange 
            var mockedDbSet = new Mock<DbSet<ICreature>>();
            var mockedDbContext = new Mock<IAquaWorldDbContext>();
            var fakeAdvert = new Mock<ICreature>();
            var validId = 15;

            // Act
            mockedDbContext.Setup(mock => mock.Set<ICreature>()).Returns(mockedDbSet.Object);
            var dataProvider = new EfAquaWorldDataProvider<ICreature>(mockedDbContext.Object);
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(fakeAdvert.Object);

            // Assert
            Assert.That(dataProvider.GetById(validId), Is.Not.Null);
            Assert.AreEqual(dataProvider.GetById(validId), fakeAdvert.Object);
        }
    }
}
