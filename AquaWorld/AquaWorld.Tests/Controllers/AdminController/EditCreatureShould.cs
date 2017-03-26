using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.AdminController
{
    [TestFixture]
    public class EditCreatureShould
    {
        [Test]
        public void ReturnView()
        {
            //Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();
            Creature creature = new Creature() { Id = 1 };

            creatureServiceMock.Setup(x => x.GetCreatureById(1)).Returns(creature);

            //Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                  creatureServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.EditCreature(1))
                .ShouldRenderDefaultView();
        }
    }
}
