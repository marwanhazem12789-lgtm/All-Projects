using Libirary_MVC_With_Repo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libirary_MVC_With_Repo.Controllers
{
    public class BorrowController : Controller
    {
        public readonly IBorrow b;
        public readonly IBook bo;
        public readonly IMember m;
        public BorrowController(IBorrow bb , IBook boo , IMember mm )
        {
            b = bb;
            bo = boo;
            m = mm;
        }
        // GET: BorrowController
        public IActionResult Index()
        {
            var w = b.GetAllBorrows();

            return View(w);
        }

        // GET: BorrowController/Create
        public IActionResult Create()
        {
            var data = new BorrowViewModel();

            data.Books = bo.GetAllBooks();
            data.Members = m.GetAllMembers();

            if (data.Books == null) data.Books = new List<Book>();
            if (data.Members == null) data.Members = new List<Member>();

            return View(data);
        }

        // POST: BorrowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BorrowViewModel collection)
        {
            if (collection.BookId == 0 || collection.MemberId == 0)
            {
                return NotFound();
            }
            else
            {
                b.AddBorrow(collection);
                return RedirectToAction(nameof(Index));
            }

            collection.Books = bo.GetAllBooks() ?? new List<Book>();
            collection.Members = m.GetAllMembers() ?? new List<Member>();
            return View(collection);
        }

        // GET: BorrowController/Edit/5
        public IActionResult Edit(int id)
        {
                var po = b.GetBorrowById(id);
            if(po == null)
            {
                return NotFound();
            }
            var data = new BorrowViewModel
            {
                Id = po.Id,
                BookId = po.BookId,
                MemberId = po.MemberId,
                BorrowDate = po.BorrowDate,
                ReturnDate = po.ReturnDate,
                Books = bo.GetAllBooks(),
                Members = m.GetAllMembers()
            };
            return View(data);
        }

        // POST: BorrowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BorrowViewModel collection)
        {
            if (id != collection.Id)
            {
                return NotFound();
            }
            b.UpdateBorrow(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: BorrowController/Delete/5
        public IActionResult Delete(int id)
        {
            var po = b.GetBorrowById(id);
            if (po == null)
            {
                return NotFound();
            }

            var data = new BorrowViewModel
            {
                Id = po.Id,
                BorrowDate = po.BorrowDate,
                ReturnDate = po.ReturnDate,
                Book = po.Book,
                Member = po.Member
            };
            return View(data);
        }
        // POST: BorrowController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, BorrowViewModel collection)
        {
            b.DeleteBorrow(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
