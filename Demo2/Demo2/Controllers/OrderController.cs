using Demo2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    public class OrderController : Controller
    {
        public readonly IOrder orderRepo;
        public readonly IMenuItem menuItemRepo;
        public OrderController(IOrder o , IMenuItem m)
        {
            this.orderRepo = o;
            this.menuItemRepo = m;
        }
        // GET: OrderController
        public IActionResult Index()
        {
                var data = orderRepo.orders();
                return View(data);
        }

        // GET: OrderController/Create
        public IActionResult Create()
        {
            var data = new OrderVM()
            {
                MenuItems = menuItemRepo.menuItems()
               
            };
            return View(data);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderVM collection)
        {

            orderRepo.AddOrder(collection);
            return RedirectToAction(nameof(Index));

        }

    }
}
