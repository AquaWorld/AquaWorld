using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using AquaWorld.Data.Models;
using AquaWorld.Data.Contracts;

namespace AquaWorld.Data
{
    public class AquaWorldDbContext : IdentityDbContext<User>, IAquaWorldDbContext
    {
        public AquaWorldDbContext()
            : base("DefaultConnection")
        {

        }

        public static AquaWorldDbContext Create()
        {
            return new AquaWorldDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
