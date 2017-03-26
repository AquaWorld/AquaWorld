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

namespace AquaWorld.Tests.Controllers.OrderController
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void RedirectToIndexActionWhenOrderServiceReturnTrue()
        {
            //// Arrange
            //var orderServiceMock = new Mock<IOrderService>();
            //var currentUser = new User() { Id = "id" };
            //var firstCreature = new Creature();
            //var secondCreature = new Creature();
            //var listOfCreatures = new List<Creature>()
            //{
            //    firstCreature,
            //    secondCreature
            //};

            //orderServiceMock.Setup(x => x.CreateOrder("id", listOfCreatures)).Returns(true);

            //// Act
            //var orderController = new AquaWorld.Web.Controllers.OrderController(orderServiceMock.Object);
            ////orderController.HttpContext.Session;

            ////Assert
            //orderController
            //    .WithCallTo(c => c.Create("id"))
            //    .ShouldRedirectTo(a => a.Index);
        }
    }
}
