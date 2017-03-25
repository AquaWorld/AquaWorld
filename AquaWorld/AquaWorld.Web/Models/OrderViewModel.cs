using AquaWorld.Data.Models;
using System;
using System.Collections.Generic;

namespace AquaWorld.Web.Models
{
    public class OrderViewModel
    {
        public OrderViewModel(Order order)
        {
            this.Id = order.Id;
            this.OrderedOn = order.OrderedOn;
            this.ItemsCount = order.ItemsCount;
            this.TotalPrice = order.TotalPrice;
            this.isProceeded = order.isProceeded;
            this.UserId = order.UserId;
            this.User = order.User;
            this.Creatures = order.Creatures;
        }

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