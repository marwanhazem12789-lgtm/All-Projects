using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Real_Libirary.Models;

namespace Real_Libirary.Controllers
{
    public class OrderController : Controller
    {
        public readonly Context c;

        public OrderController()
        {
            c = new Context();
        }

        // GET: OrderController
        public ActionResult Index()
        {
            var oo = c.Orders.Include(o => o.Customer).Include(o => o.Book).ToList();
            return View(oo);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var oo = c.Orders.Include(o => o.Customer).Include(o => o.Book).FirstOrDefault(x => x.Id == id);
            if (oo == null)
            {
                return NotFound();
            }
            return View(oo);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
           
            var data = new VM
            {
                Books = c.Books.ToList(),
                Customers = c.Customers.ToList()
            };
            return View(data);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VM collection)
        {
            var i = c.Orders.Any(x => x.CustomerId == collection.CustomerId
                                 && x.BookId == collection.BookId);

            if (i)
            {
                ModelState.AddModelError("", "This order already exists.");
                collection.Books = c.Books.ToList();
                collection.Customers = c.Customers.ToList();
                return View(collection);
            }

            var data = new Order
            {
                CustomerId = collection.CustomerId,
                BookId = collection.BookId,
                OrderDate = collection.OrderDate
            };
            c.Orders.Add(data);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Edit/5
        public IActionResult Edit(int id)
        {
            var oo = c.Orders.Find(id);
            if (oo == null)
            {
                return NotFound();
            }

            var data = new VM
            {
                CustomerId = oo.CustomerId,
                BookId = oo.BookId,
                OrderDate = oo.OrderDate,
                Books = c.Books.ToList(),
                Customers = c.Customers.ToList()
            };

            return View(data);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VM collection)
        {

            var data = new Order
            {
                Id = id,
                CustomerId = collection.CustomerId,
                BookId = collection.BookId,
                OrderDate = collection.OrderDate,
                
            };
            c.Update(data);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Delete/5
        public IActionResult Delete(int id)
        {
            var oo = c.Orders
                      .Include(o => o.Customer)
                      .Include(o => o.Book)
                      .FirstOrDefault(x => x.Id == id);

            if (oo == null)
            {
                return NotFound();
            }

            var modelForView = new VM
            {
                Id = oo.Id,
                OrderDate = oo.OrderDate,
                SingleCustomer = oo.Customer,
                SingleBook = oo.Book
            };

            return View(modelForView);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, VM collection)
        {
            var b = c.Orders.Find(id);
            if (b != null)
            {
                c.Orders.Remove(b);
                c.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
