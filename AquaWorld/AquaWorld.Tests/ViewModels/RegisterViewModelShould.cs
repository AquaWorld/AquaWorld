using AquaWorld.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaWorld.Tests.ViewModels
{
    [TestFixture]
    public class RegisterViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var registerViewModel = new RegisterViewModel();
            string username = "John";
            string password = "Agent007";
            string email = "john@gmail.com";
            string address = "Bulgaria, Sofia";

            //Act
            registerViewModel.UserName = username;
            registerViewModel.Email = email;
            registerViewModel.Address = address;
            registerViewModel.Password = password;
            registerViewModel.ConfirmPassword = password;

            //Assert
            Assert.AreEqual(registerViewModel.UserName, username);
            Assert.AreEqual(registerViewModel.Email, email);
            Assert.AreEqual(registerViewModel.Address, address);
            Assert.AreEqual(registerViewModel.ConfirmPassword, password);
            Assert.AreEqual(registerViewModel.Password, password);
        }
    }
}
