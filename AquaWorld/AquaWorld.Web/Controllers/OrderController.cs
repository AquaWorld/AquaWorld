using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using AquaWorld.Web.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            Guard.WhenArgument(orderService, "orderService").IsNull().Throw();

            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string userId)
        {
            var creaturesList = new List<Creature>();

            if (Session["CartItems"] != null)
            {
                var cartItems = Session["CartItems"] as List<Creature>;
                for (int i = 0; i < cartItems.Count; i++)
                {
                    if (creaturesList.Any(c => c.Id == cartItems[i].Id))
                    {
                        var targetCreature = creaturesList.First(c => c.Id == cartItems[i].Id);
                        targetCreature.OrderedItemsCount += 1;
                    }
                    else
                    {
                        cartItems[i].OrderedItemsCount = 1;
                        creaturesList.Add(cartItems[i]);
                    }
                }
                Session["CartItems"] = null;
            }

            bool isSuccess = this.orderService.CreateOrder(userId, creaturesList);

            return isSuccess ? RedirectToAction("Index") : RedirectToAction("OutOfStock");
        }

        public ActionResult MyOrders(string id)
        {
            var cuurrentUsersOrders = this.orderService.GetOrdersByUserId(id).ToList().Select(o => new OrderViewModel(o)).ToList();
            return View(cuurrentUsersOrders);
        }
    }
}