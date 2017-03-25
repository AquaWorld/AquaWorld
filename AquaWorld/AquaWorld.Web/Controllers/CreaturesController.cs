using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Bytes2you.Validation;
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
            Guard.WhenArgument(creatureService, "creatureService").IsNull().Throw();

            this.creatureService = creatureService;
        }

        public ActionResult Index()
        {
            var allCreatures = this.creatureService.GetAllCreatures().ToList();
            return View(allCreatures);
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var targetCreature = this.creatureService.GetCreatureById((int)id);

                return View(targetCreature);
            }
            else
            {
                return View(this.creatureService.GetAllCreatures().First());
            }
        }
    }
}