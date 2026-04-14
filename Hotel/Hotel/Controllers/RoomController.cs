using Hotel.Models;
using Hotel.REPOS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        public readonly IRoom r;
        public readonly IUser u;
        public RoomController(IRoom r, IUser u)
        {
            this.r = r;
            this.u = u;
        }
        // GET: RoomController
        public IActionResult Index()
        {
            
            return View(r.rooms());
        }


        // GET: RoomController/Create
        public IActionResult Create()
        {
            var n = new RoomVM()
            {
                Users = u.users(),
                PricePerNight = 0,
                Status = string.Empty,
                RoomNumber = 0,
                Type = string.Empty,  
            };
            return View(n);
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomVM collection)
        {
            r.add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomController/Edit/5
        public IActionResult Edit(int id)
        {
            var t = r.Get(id);
            if (t == null)
            {
                return NotFound();
            }
            var d = new RoomVM()
            {
                Id = t.Id,
                Users = u.users(),
                Type = t.Type,
                PricePerNight = t.PricePerNight,
                Status = t.Status
            };
            return View(d);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RoomVM collection)
        {
            r.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomController/Delete/5
        public IActionResult Delete(int id)
        {

            var t = r.Get(id);
            if (t == null)
            {
                return NotFound();

            }
            var data = new RoomVM()
            {
                Id = t.Id,
                Users = u.users(),
                Type = t.Type,
                PricePerNight = t.PricePerNight,
                Status = t.Status
            };
            return View(data);
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, RoomVM collection)
        {
           r.delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
