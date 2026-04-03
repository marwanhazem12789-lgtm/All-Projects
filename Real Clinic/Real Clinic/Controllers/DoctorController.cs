using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Clinic.Models;

namespace Real_Clinic.Controllers
{
    public class DoctorController : Controller
    {
        public readonly Context c;
        public DoctorController()
        {
            c = new Context();
        }
        // GET: DoctorController
        public IActionResult Index()
        {
            var d = c.Doctors.ToList();
            return View(d);
        }

        // GET: DoctorController/Details/5
        public IActionResult Details(int id)
        {
            var d = c.Doctors.FirstOrDefault(x => x.Id == id);
            if (d == null)
            {
                return NotFound();
            }
            return View(d);
        }

        // GET: DoctorController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor collection)
        {
           c.Doctors.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DoctorController/Edit/5
        public IActionResult Edit(int id)
        {
            var d = c.Doctors.Find(id);
            if(d == null)
            {
                return NotFound();
            }
            return View(d);
        }

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Doctor collection)
        {
            c.Update(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DoctorController/Delete/5
        public IActionResult Delete(int id)
        {
            var d = c.Doctors.Find(id);
            if (d == null)
            {
                return NotFound();
            }
            return View(d);
        }

        // POST: DoctorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Doctor collection)
        {
            c.Doctors.Remove(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
