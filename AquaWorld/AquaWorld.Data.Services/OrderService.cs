using AquaWorld.Data.Contracts;
using AquaWorld.Data.Models;
using AquaWorld.Data.Models.Contracts;
using AquaWorld.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaWorld.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEfAquaWorldDataProvider<Order> orderDataProvider;
        private readonly IEfAquaWorldDataProvider<Creature> creatureDataProvider;
        private readonly IOrder orderToCreate;

        public OrderService(
            IEfAquaWorldDataProvider<Order> orderDataProvider,
            IEfAquaWorldDataProvider<Creature> creatureDataProvider,
            IOrder orderToCreate)
        {
            this.orderDataProvider = orderDataProvider;
            this.creatureDataProvider = creatureDataProvider;
            this.orderToCreate = orderToCreate;
        }

        public bool CreateOrder(string userId, IList<Creature> creaturesList)
        {

            this.orderToCreate.UserId = userId;
            this.orderToCreate.OrderedOn = DateTime.Now;
            this.orderToCreate.isProceeded = false;
            this.orderToCreate.ItemsCount = creaturesList.Count();
            this.orderToCreate.Creatures = new List<Creature>();

            decimal totalPrice = 0;
            foreach (var item in creaturesList)
            {
                var currentCreature = this.creatureDataProvider.GetById(item.Id);
                this.orderToCreate.Creatures.Add(currentCreature);
                if (currentCreature.AvailableCount > 0)
                {
                    currentCreature.AvailableCount--;
                    this.creatureDataProvider.SaveChanges();
                }
                else
                {
                    return false;
                }

                totalPrice += item.Price;
            }

            this.orderToCreate.TotalPrice = totalPrice;

            this.orderDataProvider.Add((Order)this.orderToCreate);
            this.orderDataProvider.SaveChanges();
            return true;
        }

        public IQueryable<Order> GetOrdersByUserId(string userId)
        {
            return this.orderDataProvider.All().Where(o => o.UserId == userId);
        }

        public IQueryable<Order> GetAllOrders()
        {
            return this.orderDataProvider.All();
        }

        public void ProceedOrderById(int id)
        {
            var targetOrder = this.orderDataProvider.GetById(id);
            targetOrder.isProceeded = true;
            this.orderDataProvider.SaveChanges();
        }
    }
}
