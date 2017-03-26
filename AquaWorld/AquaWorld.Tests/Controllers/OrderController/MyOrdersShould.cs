using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using AquaWorld.Web.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.OrderController
{
    [TestFixture]
    class MyOrdersShould
    {
        [Test]
        public void ReturnViewWithCurrentUserOrdersList()
        {
            // Arrange
            var orderServiceMock = new Mock<IOrderService>();
            var currentUser = new User() { Id = "id" };
            var firstOrder = new Order() { UserId = "id" };
            var secondOrder = new Order() { UserId = "notMachedId" };
            var listOfOrders = new List<Order>()
            {
                firstOrder,
                secondOrder
            };

            orderServiceMock.Setup(x => x.GetOrdersByUserId("id")).Returns(listOfOrders.AsQueryable);

            // Act
            var orderController = new AquaWorld.Web.Controllers.OrderController(orderServiceMock.Object);

            //Assert
            orderController
                .WithCallTo(c => c.MyOrders("id"))
                .ShouldRenderDefaultView()
                .WithModel<List<OrderViewModel>>(model =>
                {
                    Assert.AreEqual(model.First().UserId, currentUser.Id);
                });
        }
    }
}
