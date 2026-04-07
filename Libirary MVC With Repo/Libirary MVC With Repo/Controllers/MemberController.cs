using Libirary_MVC_With_Repo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libirary_MVC_With_Repo.Controllers
{
    public class MemberController : Controller
    {
        public readonly IMember m;
        public MemberController(IMember mm)
        {
            m = mm;
        }

        // GET: MemberController
        public IActionResult Index()
        {
            var members = m.GetAllMembers();
            return View(members);
        }

        // GET: MemberController/Details/5
        public IActionResult Details(int id)
        {
            var member = m.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: MemberController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member collection)
        {
            m.AddMember(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MemberController/Edit/5
        public IActionResult Edit(int id)
        {
            var me = m.GetMemberById(id);
            if (me == null)
            {
                return NotFound();
            }
            return View(me);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Member collection)
        {
           m.UpdateMember(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            var me = m.GetMemberById(id);
            if (me == null)
            {
                return NotFound();
            }
            return View(me);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
           m.DeleteMember(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
