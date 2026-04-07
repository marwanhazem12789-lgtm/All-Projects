using Libirary_MVC_With_Repo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libirary_MVC_With_Repo.Controllers
{
    public class BookController : Controller
    {
        public readonly IBook b;
        public BookController(IBook bb)
        {
            b = bb;
        }
        // GET: BookController
        public IActionResult Index()
        {
            var books = b.GetAllBooks();
            return View(books);
        }

        // GET: BookController/Details/5
        public IActionResult Details(int id)
        {
            var bo = b.GetBookById(id);
            if (bo == null)
            {
                return NotFound();
            }
            return View(bo);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book collection)
        {
           b.AddBook(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public IActionResult Edit(int id)
        {
            var bo = b.GetBookById(id);
            if (bo == null)
            {
                return NotFound();
            }
            return View(bo);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book collection)
        {
          b.UpdateBook(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int id)
        {
            var bo = b.GetBookById(id);
            if (bo == null)
            {
                return NotFound();
            }
            return View(bo);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Book collection)
        {
         b.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
