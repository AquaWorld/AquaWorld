using System.Data.Entity;

namespace AquaWorld.Tests.Helpers
{
    public class DbSetForTest<T> : DbSet<T> where T : class
    {
    }
}
