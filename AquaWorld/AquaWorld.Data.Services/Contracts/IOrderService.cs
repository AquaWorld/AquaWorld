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
        bool CreateOrder(string userName, IList<Creature> creaturesList);

        IQueryable<Order> GetAllOrders();

        IQueryable<Order> GetOrdersByUserId(string userId);

        void ProceedOrderById(int id);
    }
}
