using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
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
                creaturesList.AddRange(cartItems);
                Session["CartItems"] = null;
            }

            bool isSuccess = this.orderService.CreateOrder(userId, creaturesList);

            return isSuccess ? RedirectToAction("Index") : RedirectToAction("OutOfStock");
        }

        public ActionResult MyOrders()
        {
            return View();
        }
    }
}