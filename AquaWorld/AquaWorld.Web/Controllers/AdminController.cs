using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICreatureService creatureService;
        
        public AdminController(ICreatureService creatureService)
        {
            this.creatureService = creatureService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCreature()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCreature([Bind(Include = "Id,Name,Category,Description,AvailableCount,ImageUrl")] Creature creature)
        {
            if (ModelState.IsValid)
            {
                this.creatureService.Create(creature);
                return RedirectToAction("Index");
            }

            return View(creature);
        }
    }
}