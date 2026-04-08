using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vechil.Models;

namespace Vechil.Controllers
{
    public class MaintenanceRecordController : Controller
    {
        private readonly IMaintenanceRecord r;
        private readonly IVehicle v;
        private readonly IMaintenanceType t;

        public MaintenanceRecordController(IMaintenanceRecord rr, IVehicle vv, IMaintenanceType tt)
        {
            r = rr;
            v = vv;
            t = tt;
        }

        // GET: MaintenanceRecordController
        public IActionResult Index()
        {
                var data = r.GetAll();
                return View(data);
        }

      
            [HttpGet]
            public IActionResult Create()
            {
                var vm = new MaintenanceRecordFormViewModel
                {
                    Vehicles = v.GetVehicles(),
                    MaintenanceTypes = t.GetMaintenanceTypes(),
                    ServiceDate = DateTime.Now 
                };

                return View(vm);
            }

        


        // POST: MaintenanceRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MaintenanceRecordFormViewModel collection)
        {
           r.Add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MaintenanceRecordController/Edit/5
        public ActionResult Edit(int id)
        {
            var b = r.GetByID(id);
            if (b == null)
            {
                return NotFound();
            }
            var data = new MaintenanceRecordFormViewModel()
            {
                Id = b.Id,
                VehicleId = b.VehicleId,
                MaintenanceTypeId = b.MaintenanceTypeId,
                ServiceDate = b.ServiceDate,
                CurrentKm = b.CurrentKm,
                Notes = b.Notes
            };
            return View(data);
        }

        // POST: MaintenanceRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MaintenanceRecordFormViewModel collection)
        {
              var n = r.GetByID(id);
            if (n == null)
            {
                return NotFound();
            }
            collection.Id = id;
            r.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MaintenanceRecordController/Delete/5
        public IActionResult Delete(int id)
        {
            var n = r.GetByID(id);
            if (n == null)
            {
                return NotFound();
            }
            var data = new MaintenanceRecordFormViewModel()
            {
                Id = n.Id,
                VehicleId = n.VehicleId,
                MaintenanceTypeId = n.MaintenanceTypeId,
                ServiceDate = n.ServiceDate,
                CurrentKm = n.CurrentKm,
                Notes = n.Notes
            };
            return View(data);
        }

        // POST: MaintenanceRecordController/Delete/5
        [HttpPost  , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete2(int id, MaintenanceRecordFormViewModel collection)
        {
            r.Delete(collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
