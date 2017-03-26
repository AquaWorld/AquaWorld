using NUnit.Framework;

namespace AquaWorld.Tests.Data.Configuration
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void SetPropertiesAutomaticMigrationsEnabledAndAutomaticMigrationDataLossAllowedToTrue()
        {
            var config = new AquaWorld.Data.Migrations.Configuration();

            Assert.AreEqual(config.AutomaticMigrationsEnabled, true);
            Assert.AreEqual(config.AutomaticMigrationDataLossAllowed, true);
        }
    }
}
