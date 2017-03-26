using AquaWorld.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquaWorld.Data.Services.Contracts
{
    public interface IOrderService
    {
        bool CreateOrder(string userId, IList<Creature> creaturesList);

        IQueryable<Order> GetAllOrders();

        IQueryable<Order> GetOrdersByUserId(string userId);

        void ProceedOrderById(int id);
    }
}
