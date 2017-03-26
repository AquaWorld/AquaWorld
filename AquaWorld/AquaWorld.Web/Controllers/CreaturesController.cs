using AquaWorld.Data.Services.Contracts;
using AquaWorld.Web.Models;
using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;

namespace AquaWorld.Web.Controllers
{
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
            var allCreatures = this.creatureService.GetAllCreatures().ToList().Select(c=> new CreatureViewModel(c)).ToList();
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