using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaWorld.Tests.Services.CreatureService
{
    [TestFixture]
    public class GetCreatureByIdShould
    {
        [TestCase(1)]
        [TestCase(5)]
        public void CallCreatureDataProviderGetAllMethodWithSameId(int correctId)
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfAquaWorldDataProvider<Creature>>();

            //Act
            var actualCreatureService =
                new AquaWorld.Data.Services.CreatureService(mockedDataProvider.Object);

            actualCreatureService.GetCreatureById(correctId);

            //Assert
            mockedDataProvider.Verify(
                service => service.GetById(correctId),
                Times.Once);
        }
    }
}
