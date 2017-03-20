using AquaWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaWorld.Data.Services.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(string userName, IList<Creature> creaturesList);
    }
}
