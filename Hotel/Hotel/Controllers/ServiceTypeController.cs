using Hotel.Models;
using Hotel.REPOS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ServiceTypeController : Controller
    {
        public readonly IServiceType s;
        public readonly IUser u;
        public ServiceTypeController(IServiceType s, IUser u)
        {
            this.s = s;
            this.u = u;
        }
        // GET: ServiceTypeController
        public IActionResult Index()
        {
            return View(s.GetServices());
        }


        // GET: ServiceTypeController/Create
        public IActionResult Create()
        {
            var t = new ServiceTypeVM()
            {
                Name = string.Empty,
                Price = 0,
                users = u.users()

            };
            return View(t);
        }

        // POST: ServiceTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceTypeVM collection)
        {
           s.add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceTypeController/Edit/5
        public IActionResult Edit(int id)
        {

            var t = s.Get(id);
            if (t == null)
            {
                return NotFound();
            }
            var d = new ServiceTypeVM()
            {
                Id = t.Id,
                users = u.users(),
                Name = t.Name,
                Price = t.Price,
            };
            return View(d);
        }

        // POST: ServiceTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ServiceTypeVM collection)
        {
          s.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceTypeController/Delete/5
        public IActionResult Delete(int id)
        {
            var t = s.Get(id);
            if (t == null)
            {
                return NotFound();

            }
            var data = new ServiceTypeVM()
            {
                Id = t.Id,
                users = u.users(),
               Name  = t.Name,
                Price = t.Price,
            };
            return View(data);
        }

        // POST: ServiceTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServiceTypeVM collection)
        {
            s.delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
