using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_Attendance_Tracking.Models;

namespace Simple_Attendance_Tracking.Controllers
{
    public class StudentController : Controller
    {
        public readonly Context c; 
        public StudentController()
        {
            c = new Context();
        }
        // GET: StudentController
        public IActionResult Index()
        {
            var s = c.Students.ToList();

            return View(s);
        }


        // GET: StudentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student collection)
        {
            c.Students.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Edit/5
        public IActionResult Edit(int id)
        {
            var s = c.Students.Find(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student collection)
        {
            c.Update(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Delete/5
        public IActionResult Delete(int id)
        {
            var s = c.Students.Find(id);
            if (s == null)
            {
                return NotFound();
            }
             
            return View(s);
        }


        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Student collection)
        {
         c.Students.Remove(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
