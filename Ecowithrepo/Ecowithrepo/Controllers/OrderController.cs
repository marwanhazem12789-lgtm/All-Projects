using Ecowithrepo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ecowithrepo.Controllers
{
    public class OrderController : Controller
    {
        IOrder repo;
        Context db = new Context();

        public OrderController(IOrder _repo) { repo = _repo; }

        public IActionResult Index()
        {
            var orders = repo.GetAll();
            return View(orders);
        }

        public IActionResult Create()
        {
            var vm = new OrderViewModel
            {
                Customers = db.Customers.ToList(),
                Products = db.Products.Select(p => new ProductSelectionViewModel
                {
                    ProductId = p.ProductID,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            repo.Add(model);
            return RedirectToAction("Index");
        }
    }
}
