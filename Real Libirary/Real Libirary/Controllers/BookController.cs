using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Libirary.Models;

namespace Real_Libirary.Controllers
{
    public class BookController : Controller
    {
        public readonly Context c;
        public BookController()
        {
            c = new Context();
        }

        // GET: BookController
        public IActionResult Index()
        {
            var b = c.Books.ToList();
            return View(b);
        }

        // GET: BookController/Details/5
        public IActionResult Details(int id)
        {
            var b = c.Books.FirstOrDefault(x => x.Id == id);
                if (b == null)
                {
                    return NotFound();
            }
            return View(b);
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book collection)
        {
           c.Books.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public IActionResult Edit(int id)
        {
            var b = c.Books.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book collection)
        {
            c.Update( collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int id)
        {
            var b = c.Books.Find(id);
                    if (b == null)
                    {
                        return NotFound();
            }
            return View(b);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Book collection)
        {
          c.Books.Remove(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
