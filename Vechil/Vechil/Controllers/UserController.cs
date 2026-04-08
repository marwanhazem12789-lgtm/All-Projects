using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vechil.Models;

namespace Vechil.Controllers
{
    public class UserController : Controller
    {
        public readonly IUser u;
        public UserController(IUser us)
        {
            u = us;
        }
        // GET: UserController
        public IActionResult Index()
        {
            var data = u.GetUsers();
            return View(data);
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
           u.AddUser(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Edit/5
        public IActionResult Edit(int id)
        {
            var bo = u.GetUserById(id);
            if (bo == null)
            {
                return NotFound();
            }
            return View(bo);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User collection)
        {
           u.UpdateUser(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public IActionResult Delete(int id)
        {
            var bo = u.GetUserById(id);
            if (bo == null)
            {
                return NotFound();
            }
            return View(bo);
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, User collection)
        {
          u.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
