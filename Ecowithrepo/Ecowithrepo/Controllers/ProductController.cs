using Microsoft.AspNetCore.Mvc;
using Ecowithrepo.Models;

namespace Ecowithrepo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productRepo;

        public ProductController(IProduct productRepo)
        {
            _productRepo = productRepo;
        }

        public ActionResult Index()
        {
            var products = _productRepo.GetAll();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            
                _productRepo.Add(product);
                return RedirectToAction(nameof(Index));
           
        }

        public ActionResult Edit(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (id != product.ProductID) return BadRequest();

            
                _productRepo.Update(product);
                return RedirectToAction(nameof(Index));
            
        }

        public ActionResult Delete(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}