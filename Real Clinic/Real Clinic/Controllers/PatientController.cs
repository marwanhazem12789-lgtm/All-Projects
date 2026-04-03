using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Clinic.Models;

namespace Real_Clinic.Controllers
{
    public class PatientController : Controller
    {
        public readonly Context c;
        public PatientController()
        {
            c = new Context();
        }
        // GET: PatientController
        public IActionResult Index()
        {
            var p = c.Patients.ToList();
            return View(p);
        }

        // GET: PatientController/Details/5
        public IActionResult Details(int id)
        {
            var p = c.Patients.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // GET: PatientController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient collection)
        {
           c.Patients.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PatientController/Edit/5
        public IActionResult Edit(int id)
        {
            var p = c.Patients.Find(id);
                if(p == null)
                {
                    return NotFound();
            }   
            return View(p);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Patient collection)
        {
            c.Update(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PatientController/Delete/5
        public IActionResult Delete(int id)
        {
            var p = c.Patients.Find(id);
            if(p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Patient collection)
        {
            c.Patients.Remove(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
