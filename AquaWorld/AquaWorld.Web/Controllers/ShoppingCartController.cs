﻿using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Web.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ICreatureService creatureService;

        public ShoppingCartController(ICreatureService creatureService)
        {
            this.creatureService = creatureService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int? id)
        {
            int parsedId = (id == null) ? 0 : (int)id;

            var cartItem = this.creatureService.GetCreatureById(parsedId);

            if (Session["CartItems"] == null)
            {
                List<Creature> cartItems = new List<Creature>();
                cartItems.Add(cartItem);
                Session["CartItems"] = cartItems;
            }
            else
            {
                var cartItems = Session["CartItems"] as List<Creature>;
                cartItems.Add(cartItem);
                Session["CartItems"] = cartItems;
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int? id)
        {
            int parsedId = (id == null) ? 0 : (int)id;

            var cartItem = this.creatureService.GetCreatureById(parsedId);

            if (Session["CartItems"] != null)
            {
                var cartItems = Session["CartItems"] as List<Creature>;
                var target = cartItems.FirstOrDefault(x => x.Id == cartItem.Id);
                cartItems.Remove(target);
                Session["CartItems"] = cartItems;
            }

            return RedirectToAction("Index");
        }
    }
}