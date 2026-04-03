using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Controllers
{
    public class EnrollmentController : Controller
    {
        public readonly Context c;
        public EnrollmentController()
        {
            c = new Context();
        }

        // GET: EnrollmentController
        public IActionResult Index()
        {
            var er = c.Enrollments.Include(e => e.Student).Include(e => e.Course).ToList();
            return View(er);
        }

        public IActionResult Create()
        {
            var cc = new VM {
                Students =  c.Students.ToList(),
              Courses =  c.Courses.ToList()
            };

            return View(cc);
        }

        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VM collection)
        {
            var data = new Enrollment()
            {
                StudentId = collection.StudentId,
                CourseId = collection.CourseId,
                RegisterDate = DateOnly.FromDateTime(DateTime.Now)
            };
            c.Enrollments.Add(data);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
