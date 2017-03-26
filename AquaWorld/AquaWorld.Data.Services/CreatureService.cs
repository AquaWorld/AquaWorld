using AquaWorld.Data.Services.Contracts;
using System.Linq;
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

        public IQueryable<Creature> GetAllCreatures()
        {
            return this.creatureDataProvider.All();
        }

        public Creature GetCreatureById(int id)
        {
            return this.creatureDataProvider.GetById(id);
        }

        public void UpdateCreature(Creature creature)
        {
            Guard.WhenArgument(creature, "creature").IsNull().Throw();

            var targetCreature = this.creatureDataProvider.GetById(creature.Id);
            targetCreature.Name = creature.Name;
            targetCreature.Description = creature.Description;
            targetCreature.AvailableCount = creature.AvailableCount;
            targetCreature.Price = creature.Price;
            targetCreature.ImageUrl = creature.ImageUrl;
            targetCreature.Category = creature.Category;

            this.creatureDataProvider.Update(targetCreature);
            this.creatureDataProvider.SaveChanges();
        }
    }
}
