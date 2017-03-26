using AquaWorld.Web.Models;
using NUnit.Framework;

namespace AquaWorld.Tests.ViewModels
{
    [TestFixture]
    public class LoginViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var loginViewModel = new LoginViewModel();
            string username = "John";
            string password = "Agent007";

            //Act
            loginViewModel.UserName = username;
            loginViewModel.Password = password;
            loginViewModel.RememberMe = false;

            //Assert
            Assert.AreEqual(loginViewModel.UserName, username);
            Assert.AreEqual(loginViewModel.Password, password);
            Assert.AreEqual(loginViewModel.RememberMe, false);
        }
    }
}
