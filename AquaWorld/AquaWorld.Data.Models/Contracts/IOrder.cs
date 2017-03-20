using System;
using System.Collections.Generic;

namespace AquaWorld.Data.Models.Contracts
{
    public interface IOrder
    {
        int Id { get; set; }

        DateTime OrderedOn { get; set; }

        decimal TotalPrice { get; set; }

        int ItemsCount { get; set; }

        string UserId { get; set; }

        User User { get; set; }

        IList<Creature> Creatures { get; set; }
    }
}
