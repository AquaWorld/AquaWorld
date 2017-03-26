using AquaWorld.Web.Models;
using NUnit.Framework;

namespace AquaWorld.Tests.ViewModels
{
    [TestFixture]
    public class ExternalLoginConfirmationViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var externalLoginConfirmationViewModel = new ExternalLoginConfirmationViewModel();
            string email = "john@gmail.com";
            //Act
            externalLoginConfirmationViewModel.Email = email;

            //Assert
            Assert.AreEqual(externalLoginConfirmationViewModel.Email, email);
        }
    }
}
