using Demo2Web.Models;
using Demo2Web.Repos.Faces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2Web.Controllers
{
    public class MenuIItemController : Controller
    {
        public readonly IMenuItem m;
        public readonly ICategory c;
        public MenuIItemController(IMenuItem m, ICategory c)
        {
            this.m = m;
            this.c = c;
        }
        // GET: MenuIItemController
        public IActionResult Index()
        {
                var e = m.GetAll();
                return View(e);
        }

        // GET: MenuIItemController/Details/5
        public IActionResult Details(int id)
        {
            var e = m.GetById(id);
            if (e == null)
            {
                return NotFound();
            }
            return View(e);
        }

        // GET: MenuIItemController/Create
        public IActionResult Create()
        {
            var data = new MenuItemVM()
            {
                Categories = c.GetAll(),
                Price = 0.0,
                Name = string.Empty
            };
            return View(data);
        }

        // POST: MenuIItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItemVM collection)
        {
           m.add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MenuIItemController/Edit/5
        public IActionResult Edit(int id)
        {
                var e = m.GetById(id);
            if (e == null)
            {
                return NotFound();
            }
            var data = new MenuItemVM()
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                CategoryId = e.CategoryId,
                Categories = c.GetAll()
            };
            return View(data);
        }

        // POST: MenuIItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MenuItemVM collection)
        {
            m.Updat(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MenuIItemController/Delete/5
        public IActionResult Delete(int id)
        {
                var e = m.GetById(id);
            if (e == null)
            {
               return NotFound();

            }
            var data = new MenuItemVM()
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                category = e.category
            };
            return View(data);
        }

        // POST: MenuIItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, MenuItemVM collection)
        {
            m.delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
