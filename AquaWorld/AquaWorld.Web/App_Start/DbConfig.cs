using AquaWorld.Data;
using AquaWorld.Data.Migrations;
using System.Data.Entity;

namespace AquaWorld.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AquaWorldDbContext, Configuration>());
            AquaWorldDbContext.Create().Database.CreateIfNotExists();
        }
    }
}