using Hotel.Models;
using Hotel.REPOS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class BookingRecordController : Controller
    {

        public readonly IBookingRecord b;
        public readonly IUser u;
        public readonly IServiceType s;
        public readonly IRoom r;

        public BookingRecordController(IBookingRecord b, IUser u, IServiceType s, IRoom r)
        {
            this.b = b;
            this.u = u;
            this.s = s;
            this.r = r;
        }


        // GET: BookingRecordController
        public IActionResult Index()
        {

            return View(b.Getall());
        }

        // GET: BookingRecordController/Create
        public IActionResult Create()
        {
            var t = new BookingRecordVM()
            {
                Rooms = r.rooms(),
                Users = u.users(),
                ServiceTypes = s.GetServices(),
                TotalCost = 0,
                Notes = string.Empty
            };
            return View(t);
        }

        // POST: BookingRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookingRecordVM collection)
        {
            b.add(collection);
            return RedirectToAction("Index");
        }

        // GET: BookingRecordController/Edit/5
        public IActionResult Edit(int id)
        {

            var t = b.get(id);
            if (t == null)
            {
                return NotFound();
            }
            var d = new BookingRecordVM()
            {
                Id = t.Id,
               Users = u.users(),
               Rooms = r.rooms(),
               ServiceTypes = s.GetServices(),
               TotalCost = t.TotalCost,
               Notes=t.Notes,
            };
            return View(d);
        }

        // POST: BookingRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookingRecordVM collection)
        {
            b.update(collection);
            return RedirectToAction("Index");
        }

        // GET: BookingRecordController/Delete/5
        public IActionResult Delete(int id)
        {
            var t = b.get(id);
            if (t == null)
            {
                return NotFound();

            }
            var data = new BookingRecordVM()
            {
               Id =t.Id,
               User = t.User,
               Room = t.Room,
               ServiceType = t.ServiceType,
               TotalCost = t.TotalCost

                
            };
            return View(data);
        }

        // POST: BookingRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookingRecordVM collection)
        {
            b.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
