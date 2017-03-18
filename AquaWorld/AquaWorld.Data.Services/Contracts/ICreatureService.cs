﻿using AquaWorld.Data.Models;
using System.Linq;

namespace AquaWorld.Data.Services.Contracts
{
    public interface ICreatureService
    {
        void Create(Creature creature);

        IQueryable<Creature> GetAllCreatures();
    }
}
