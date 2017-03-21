using AquaWorld.Data.Models.Contracts;
using System;
using System.Collections.Generic;

namespace AquaWorld.Data.Models
{
    public class Order : IOrder
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public int ItemsCount { get; set; }

        public bool isProceeded { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual IList<Creature> Creatures { get; set; }
    }
}
