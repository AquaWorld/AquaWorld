using AquaWorld.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICreatureService creatureService;

        public HomeController(ICreatureService creatureService)
        {
            this.creatureService = creatureService;
        }

        public ActionResult Index()
        {
            return View(this.creatureService.GetAllCreatures());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}