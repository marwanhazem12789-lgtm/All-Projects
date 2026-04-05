using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Attendance_Tracking.Models;

namespace Simple_Attendance_Tracking.Controllers
{
    public class AttendanceController : Controller
    {
        public readonly Context c;
        public AttendanceController()
        {
            c = new Context();
        }
        // GET: AttendanceController
        public ActionResult Index()
        {
            var a = c.Attendances.Include(a => a.Student).Include(a => a.Subject).ToList();
            return View(a);
        }

        // GET: AttendanceController/Create
        public ActionResult Create()
        {
            var adat = new VM
            {
                Students = c.Students.ToList(),
                Subjects = c.Subjects.ToList(),
            };
            return View(adat);
        }

        // POST: AttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VM collection)
        {
           var data = new Attendance
            {
                StudentId = collection.StudentId,
                SubjectId = collection.SubjectId,
                Status = collection.Status,
                Date = DateOnly.FromDateTime(DateTime.Now)
            };
            c.Attendances.Add(data);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: AttendanceController/Edit/5
        public ActionResult Edit(int id)
        {
            var a = c.Attendances.Find(id);
            if (a == null)
            {
                return NotFound();
            }
                var adat = new VM
                {
                    Id = a.Id,
                    StudentId = a.StudentId,
                    SubjectId = a.SubjectId,
                    Status = a.Status,
                    Students = c.Students.ToList(),
                    Subjects = c.Subjects.ToList(),
                };
            return View(adat);
        }

        // POST: AttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VM collection)
        {
            var a = c.Attendances.Find(id);
            if (a == null)
            {
                return NotFound();
            }
          a.StudentId = collection.StudentId;
            a.SubjectId = collection.SubjectId;
            a.Status = collection.Status;
            a.Date = DateOnly.FromDateTime(DateTime.Now);
            c.Update(a);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: AttendanceController/Delete/5
        public IActionResult Delete(int id)
        {
            var a = c.Attendances
                     .Include(s => s.Student)
                     .Include(sub => sub.Subject)
                     .FirstOrDefault(m => m.Id == id);
            if (a == null)
            {
                return NotFound();
            }

            var modelForView = new VM
            {
                Id = a.Id,
                Status = a.Status,
                StudentId = a.StudentId,
                SubjectId = a.SubjectId,
                Student = a.Student,
                Subject = a.Subject
            };

            return View(modelForView);
        }

        // POST: AttendanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, VM collection)
        {
            var b = c.Attendances.Find(id);
            if (b != null)
            {
                c.Attendances.Remove(b);
                c.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
