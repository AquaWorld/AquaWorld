using AquaWorld.Data;
using System.Data.Entity;

namespace AquaWorld.Tests.Helpers
{
    public class DbContextForTest : AquaWorldDbContext
    {
        public void TestModelCreation(DbModelBuilder model)
        {
            OnModelCreating(model);
        }
    }
}
