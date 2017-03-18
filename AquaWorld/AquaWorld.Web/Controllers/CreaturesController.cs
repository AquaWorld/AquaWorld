using AquaWorld.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaWorld.Web.Controllers
{
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
    }
}