using Demo2Web.Models;
using Demo2Web.Repos.Faces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Demo2Web.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategory c;
        public CategoryController(ICategory c)
        {
            this.c = c;
        }
        // GET: CategoryController
        public IActionResult Index()
        {
            var e = c.GetAll();
            return View(e);
        }

        // GET: CategoryController/Details/5
        public IActionResult Details(int id)
        {
            var e = c.GetById(id);  
            if(e == null)
            {
                return NotFound();
            }
            return View(e);
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category collection)
        {
            c.add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            var e = c.GetById(id);
            if(e == null) {return NotFound(); }
            return View(e);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category collection)
        {
            c.Updat(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public IActionResult Delete(int id)
        {
            var e = c.GetById(id);
            if (e == null) { return NotFound(); }
            return View(e);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Category collection)
        {
           c.delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
