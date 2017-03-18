using AquaWorld.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AquaWorld.Web.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class CreaturesController : Controller
    {
        private readonly ICreatureService creatureService;

        public CreaturesController(ICreatureService creatureService)
        {
            this.creatureService = creatureService;
        }

        public ActionResult Index()
        {
            var allCreatures = this.creatureService.GetAllCreatures().ToList();
            return View(allCreatures);
        }

        public ActionResult Details(int? id)
        {
            int parsedId = (id == null) ? 0 : (int)id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var targetCreature = this.creatureService.GetCreatureById(parsedId);
            return View(targetCreature);
        }

        public ActionResult AddToCart(int? id)
        {
            int parsedId = (id == null) ? 0 : (int)id;

            var cartItem = this.creatureService.GetCreatureById(parsedId);

            //Session["CartName"] = cartItem.Name;
            //Session["CartImage"] = cartItem.ImageUrl;

            return RedirectToAction("Index");
        }
    }
}