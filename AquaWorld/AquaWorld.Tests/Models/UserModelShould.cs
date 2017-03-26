using AquaWorld.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using NUnit.Framework;

namespace AquaWorld.Tests.Models
{
    [TestFixture]
    public class UserModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            User actualUser = new User()
            {
                UserName = "John",
                Email = "john@gmail.com",
                Address = "London"
            };

            //Assert
            Assert.That(
                () => new User(),
                Is.InstanceOf<IdentityUser>());

            Assert.AreEqual(actualUser.UserName, "John");
            Assert.AreEqual(actualUser.Email, "john@gmail.com");
            Assert.AreEqual(actualUser.Address, "London");
        }
    }
}
