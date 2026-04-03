using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Orders.Models;

namespace Real_Orders.Controllers
{
    public class ProductController : Controller
    {
        public readonly Context c;
        public ProductController()
        {
            c = new Context();
        }
        // GET: ProductController
        public IActionResult Index()
        {
            var p = c.Products.ToList();
            return View(p);
        }

      

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product collection)
        {
            c.Products.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
            var p = c.Products.FirstOrDefault(x => x.Id == id);
           if(p == null) { return NotFound(); }
            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product collection)
        {
            c.Update(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            var p = c.Products.Find(id);
            if (p == null) { return NotFound(); }
            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product collection)
        {
          
     
                c.Products.Remove(collection);
                c.SaveChanges();
                return RedirectToAction(nameof(Index));

        }
    }
}
