﻿using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace AquaWorld.Tests.Controllers.ErrorController
{
    [TestFixture]
    public class BadRequestShould
    {
        [Test]
        public void ReturnView()
        {
            //Arrange & Act
            var errorController = new AquaWorld.Web.Controllers.ErrorController();

            //Assert
            errorController
                .WithCallTo(c => c.BadRequest())
                .ShouldRenderDefaultView();
        }
    }
}
