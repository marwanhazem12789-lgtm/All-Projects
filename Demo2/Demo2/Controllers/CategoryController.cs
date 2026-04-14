using Demo2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategory categoryRepo;
        public CategoryController( ICategory c)
        {
            this.categoryRepo = c;        }
        // GET: CategoryController
        public IActionResult Index()
        {
            var data = categoryRepo.Getall();
            return View(data);
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
            categoryRepo.AddCategory(collection);
            return RedirectToAction(nameof(Index));
        }


    }
}
