using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NuGet.Versioning;
using Real_Clinic.Models;

namespace Real_Clinic.Controllers
{
    public class AppointmentController : Controller
    {
        public readonly Context c;
        public AppointmentController()
        {
            c = new Context();
        }
        // GET: AppointmentController
        public IActionResult Index()
        {
            var a  = c.Appointments.Include(c => c.Doctor).Include(c => c.Patient).ToList();
            return View(a);
        }

        // GET: AppointmentController/Details/5
        public IActionResult Details(int id)
        {
            var a = c.Appointments.Include(c => c.Doctor).Include(c => c.Patient).FirstOrDefault(x => x.Id == id);
            if (a == null)
            {
                return NotFound();
            }
            return View(a);
        }

        // GET: AppointmentController/Create
        public IActionResult Create()
        {
            var data = new VM
            {
                Doctors = c.Doctors.ToList(),
                Patients = c.Patients.ToList()
            };
            return View(data);
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VM collection)
        {
                var data = new Appointment
                {
                    DoctorId = collection.doctorId,
                    PatientId = collection.tientId,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Notes = collection.notes
                };
                c.Appointments.Add(data);
                c.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        // GET: AppointmentController/Edit/5
        public IActionResult Edit(int id)
        {
            var appointment = c.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }
            var data = new VM
            {
                doctorId = appointment.DoctorId,
                tientId = appointment.PatientId,
                notes = appointment.Notes,
                date = appointment.Date,
                Doctors = c.Doctors.ToList(),
                Patients = c.Patients.ToList()
            };
            return View(data);
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VM collection)
        {
            var appointment = c.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }
            appointment.DoctorId = collection.doctorId;
            appointment.PatientId = collection.tientId;
            appointment.Notes = collection.notes;
            appointment.Date = collection.date;
            c.Appointments.Update(appointment);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: AppointmentController/Delete/5
        public IActionResult Delete(int id)
        {
            var a = c.Appointments.Include(c => c.Doctor).Include(c => c.Patient).FirstOrDefault(x => x.Id == id);
            if (a == null)
            {
                return NotFound();
            }
            return View(a);

        }

        // POST: AppointmentController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
         var a = c.Appointments.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            c.Appointments.Remove(a);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
