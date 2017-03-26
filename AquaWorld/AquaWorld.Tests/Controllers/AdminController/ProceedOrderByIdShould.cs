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
    public class ProceedOrderByIdShould
    {
        [Test]
        public void CallOrderServiceProceedOrderByIdMethodWithPassedId()
        {
            //Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();

            //Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                  creatureServiceMock.Object, orderServiceMock.Object);

            adminController.ProceedOrderById(1);

            //Assert
            orderServiceMock.Verify(x => x.ProceedOrderById(1), Times.Once);
        }

        [Test]
        public void RedirectToActionCheckOrders()
        {
            //Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();

            //Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                  creatureServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.ProceedOrderById(1))
                .ShouldRedirectTo(x => x.CheckOrders);
        }
    }
}
