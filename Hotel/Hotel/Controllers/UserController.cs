using Hotel.Models;
using Hotel.REPOS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class UserController : Controller
    {
        public readonly IUser u;
        public UserController(IUser u)
        {
            this.u = u;
        }
        // GET: UserController
        public IActionResult Index()
        {
            return View(u.users());
        }

        // GET: UserController/Details/5
        public IActionResult Details(int id)
        {
            var t = u.GetById(id);
            if (t == null)
            {
                return NotFound();
            }
            return View(t);
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User collection)
        {
           u.Add(collection);
            return RedirectToAction("Index");
        }

        // GET: UserController/Edit/5
        public IActionResult Edit(int id)
        {
            var t = u.GetById(id);
            if(t == null)
            {
                return NotFound();
            }
            return View(t);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User collection)
        {
            u.Update(collection);
            return RedirectToAction(nameof(Index));  
        }

        // GET: UserController/Delete/5
        public IActionResult Delete(int id)
        {
            var t = u.GetById(id);
            if (t == null)
            {
                return NotFound();
            }
            return View(t);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, User collection)
        {
            u.Delete(id);
            return RedirectToAction(nameof(Index
                ));
        }
    }
}
