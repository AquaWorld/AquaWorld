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
    public class HomeController : Controller
    {
        private readonly ICreatureService creatureService;

        public HomeController(ICreatureService creatureService)
        {
            Guard.WhenArgument(creatureService, "creatureService").IsNull().Throw();

            this.creatureService = creatureService;
        }

        [OutputCache(Duration = 300)]
        public ActionResult Index()
        {
            List<CreatureViewModel> creaturesList = 
                this.creatureService.GetAllCreatures().Take(5).ToList().Select(c => new CreatureViewModel(c)).ToList();

            return View(creaturesList);
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