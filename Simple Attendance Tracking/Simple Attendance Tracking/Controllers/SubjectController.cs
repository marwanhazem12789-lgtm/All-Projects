using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_Attendance_Tracking.Models;

namespace Simple_Attendance_Tracking.Controllers
{
    public class SubjectController : Controller
    {
        public readonly Context c;
        public SubjectController()
        {
            c = new Context();
        }
        // GET: SubjectController
        public IActionResult Index()
        {
            var ss = c.Subjects.ToList();
            return View(ss);
        }

        // GET: SubjectController/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject collection)
        {
           c.Subjects.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }

    }
}
