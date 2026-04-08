using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vechil.Models;

namespace Vechil.Controllers
{
    public class VehicleController : Controller
    {

        public readonly IVehicle v;
        public readonly IUser u;

        public VehicleController(IVehicle ve , IUser ue)
        {
            v = ve;
            u = ue;
        }
        // GET: VehicleController
        public IActionResult Index()
        {
            var data = v.GetVehicles();
                return View(data);
        }


        // GET: VehicleController/Create
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new VechailVM();

            vm.users = u.GetUsers();

            return View(vm);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VechailVM collection)
        {
          v.AddVehicle(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: VehicleController/Edit/5
        public IActionResult Edit(int id)
        {
            var bo = v.GetVehicleById(id);
            if(bo == null)
            {
                return NotFound();
            }
             var data = new VechailVM()
             {
                 Id = bo.Id,
                 PlateNumber = bo.PlateNumber,
                 Brand = bo.Brand,
                 Model = bo.Model,
                 Year = bo.Year,
                 users = u.GetUsers()
             };
            return View(data);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VechailVM collection)
        {
            if (id != collection.Id)
            {
                return NotFound();
            }
            v.UpdateVehicle(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: VehicleController/Delete/5
        public IActionResult Delete(int id)
        {
            var bo = v.GetVehicleById(id);
            if (bo == null)
            {
                return NotFound();
            }

            var data = new VechailVM()
            {
                Id = bo.Id,
                PlateNumber = bo.PlateNumber,
                Brand = bo.Brand,
                Model = bo.Model,
                Year = bo.Year,
                UserId = bo.UserId
            };  
            return View(data);
        }

        // POST: VehicleController/Delete/5
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete2(int id, VechailVM collection)
        {
            v.DeleteVehicle(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
