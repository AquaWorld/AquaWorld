using AquaWorld.Data.Models;
using AquaWorld.Data.Services.Contracts;
using Bytes2you.Validation;
using System.Web.Mvc;

namespace AquaWorld.Web.Areas.Admin
{
    public class AdminController : Controller
    {
        private readonly ICreatureService creatureService;
        private readonly IOrderService orderService;

        public AdminController(ICreatureService creatureService, IOrderService orderService)
        {
            Guard.WhenArgument(creatureService, "creatureService").IsNull().Throw();
            Guard.WhenArgument(orderService, "orderService").IsNull().Throw();

            this.creatureService = creatureService;
            this.orderService = orderService;
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

        public ActionResult CheckOrders()
        {
            return View(this.orderService.GetAllOrders());
        }

        public ActionResult ProceedOrderById(int orderId)
        {
            this.orderService.ProceedOrderById(orderId);
            return RedirectToAction("CheckOrders");
        }
    }
}