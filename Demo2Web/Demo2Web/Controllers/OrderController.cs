using Demo2Web.Models;
using Demo2Web.Repos.Faces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2Web.Controllers
{
    public class OrderController : Controller
    {
        public readonly IMenuItem m;
        public readonly IOrder o;
        public OrderController(IMenuItem m, IOrder o)
        {
            this.m = m;
            this.o = o;
        }
        // GET: OrderController
        public IActionResult Index()
        {
            var e = o.GetAll();
            return View(e);
        }

        // GET: OrderController/Details/5
        public IActionResult Details(int id)
        {
            var e = o.GetById(id);
             if (e == null)
             {
                 return NotFound();
            }
            return View(e);
        }

        // GET: OrderController/Create
        public IActionResult Create()
        {
            var ndData = new OrderVM()
            {
                MenuItems = m.GetAll(),
                Quantity = 0,
                
            };
            return View(ndData);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderVM collection)
        {
            o.add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Edit/5
        public IActionResult Edit(int id)
        {
            var e = o.GetById(id);
            if (e == null)
            {
                return NotFound();
            }
            var dat = new OrderVM()
            {
                    Id = e.Id,
                MenuItemId = e.MenuItemId,
                Quantity = e.Quantity,
                MenuItems = m.GetAll()
            };
            return View(dat);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderVM collection)
        {
            o.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Delete/5
        public IActionResult Delete(int id)
        {
            var e = o.GetById(id);
            if (e == null)
            {
                return NotFound();
            } 
            var dat = new OrderVM()
            {
                Id = e.Id,
                MenuItemId = e.MenuItemId,
                Quantity = e.Quantity,
                menuItem = e.menuItem
            };
            return View(dat);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, OrderVM collection)
        {
          o.delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
