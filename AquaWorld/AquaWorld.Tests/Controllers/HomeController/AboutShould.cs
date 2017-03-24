using AquaWorld.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.HomeController
{
    [TestFixture]
    public class AboutShould
    {
        [Test]
        public void ReturnViewWithListOfCorrectModelsWhenThereAreAnyExisting()
        {
            // Arrange
            var creatureServiceMock = new Mock<ICreatureService>();

            // Act
            var homeController = new AquaWorld.Web.Controllers.HomeController(creatureServiceMock.Object);
            var viewResult = homeController.About() as ViewResult;

            //Assert
            homeController
                .WithCallTo(c => c.About())
                .ShouldRenderDefaultView();

            Assert.AreEqual("Your application description page.", viewResult.ViewData["Message"]);
        }
    }
}
