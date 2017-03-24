using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.HomeController
{
    [TestFixture]
    public class ContactShould
    {
        [Test]
        public void ReturnViewWithListOfCorrectModelsWhenThereAreAnyExisting()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();

            // Act
            var homeController = new AquaWorld.Web.Controllers.HomeController(creatureServiceMock.Object);
            var viewResult = homeController.Contact() as ViewResult;

            //Assert
            homeController
                .WithCallTo(c => c.Contact())
                .ShouldRenderDefaultView();

            Assert.AreEqual("Your contact page.", viewResult.ViewData["Message"]);
        }
    }
}
