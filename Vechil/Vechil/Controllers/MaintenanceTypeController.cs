using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vechil.Models;

namespace Vechil.Controllers
{
    public class MaintenanceTypeController : Controller
    {
        public readonly IMaintenanceType m;
        public MaintenanceTypeController(IMaintenanceType mt)
        {
            m = mt;
        }
        // GET: MaintenanceTypeController
        public IActionResult Index()
        {
                var data = m.GetMaintenanceTypes();
            return View(data);
        }



        // GET: MaintenanceTypeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MaintenanceType collection)
        {
            m.AddMaintenanceType(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MaintenanceTypeController/Edit/5
        public IActionResult Edit(int id)
        {
            var data = m.GetMaintenanceTypeById(id);
                if(data == null)
                {
                    return NotFound();
            }
            return View(data);
        }

        // POST: MaintenanceTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MaintenanceType collection)
        {
           m.UpdateMaintenanceType(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: MaintenanceTypeController/Delete/5
        public IActionResult Delete(int id)
        {
                var data = m.GetMaintenanceTypeById(id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: MaintenanceTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, MaintenanceType collection)
        {
         m.DeleteMaintenanceType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
