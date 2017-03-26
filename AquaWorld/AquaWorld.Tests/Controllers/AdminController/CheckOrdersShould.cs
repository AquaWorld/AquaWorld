using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.AdminController
{
    [TestFixture]
    public class CheckOrdersShould
    {
        [Test]
        public void ReturnView()
        {
            //Arrange
            var creatureServiceMock = new Mock<ICreatureService>();
            var orderServiceMock = new Mock<IOrderService>();
            Order order = new Order();
            var ordersList = new List<Order>() { order };
            orderServiceMock.Setup(x => x.GetAllOrders()).Returns(ordersList.AsQueryable);

            //Act
            var adminController = new AquaWorld.Web.Areas.Admin.AdminController(
                  creatureServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.CheckOrders())
                .ShouldRenderDefaultView();
        }
    }
}
