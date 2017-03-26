using System.Data.Entity.Migrations;

namespace AquaWorld.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AquaWorld.Data.AquaWorldDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

    }
}
