using AquaWorld.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaWorld.Data.Models.Contracts;
using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using Bytes2you.Validation;

namespace AquaWorld.Data.Services
{
    public class CreatureService : ICreatureService
    {
        private readonly IEfAquaWorldDataProvider<Creature> creatureDataProvider;

        public CreatureService(IEfAquaWorldDataProvider<Creature> creatureDataProvider)
        {
            Guard.WhenArgument(creatureDataProvider, "creatureDataProvider").IsNull().Throw();

            this.creatureDataProvider = creatureDataProvider;
        }

        public void Create(Creature creature)
        {
            Guard.WhenArgument(creature, "creature").IsNull().Throw();

            this.creatureDataProvider.Add(creature);
            this.creatureDataProvider.SaveChanges();
        }
    }
}
