using Demo2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    public class MenuItemController : Controller
    {
        public readonly IMenuItem menuItemRepo;
        public readonly ICategory categoryRepo;
        public MenuItemController(IMenuItem m , ICategory c)
        {
            this.menuItemRepo = m;
                this.categoryRepo = c;
        }
        // GET: MenuItemController
        public IActionResult Index()
        {
                var data = menuItemRepo.menuItems();

            return View(data);
        }

        // GET: MenuItemController/Create
        public IActionResult Create()
        {
            var data = new MenuItemVM();
            data.Categores = categoryRepo.Getall();
            if (data.Categores == null)
            {
                data.Categores = new List<Category>();
            }

            return View(data);
        }

        // POST: MenuItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuItemVM collection)
        {
            menuItemRepo.AddMenuItem(collection);
            return RedirectToAction(nameof(Index));
        }

    }
}
