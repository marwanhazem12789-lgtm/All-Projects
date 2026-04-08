using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Vechil.Models
{
    public class VehicleRepo : IVehicle
    {
        public readonly Context c;
        public VehicleRepo()
        {
            c = new Context();
        }
        public void AddVehicle(VechailVM vehicle)
        {
            var data = new Vehicle
            {
                PlateNumber = vehicle.PlateNumber,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                UserId = vehicle.UserId, 
            };

            c.Vehicles.Add(data);
            c.SaveChanges();
        }
        public void DeleteVehicle(int id)
        {
            var v = c.Vehicles.Find(id);
            if (v != null)
            {
                c.Vehicles.Remove(v);
                c.SaveChanges();
            }
        }
        public Vehicle GetVehicleById(int id)
        {
            return c.Vehicles
                                .Include(b => b.User)
                                
                                .FirstOrDefault(b => b.Id == id);
        }
        public List<Vehicle> GetVehicles()
        {
            return c.Vehicles.Include(a => a.User).ToList();
        }
        public void UpdateVehicle(VechailVM vehicle)
        {
            var e = c.Vehicles.Find(vehicle.Id);
            if (e != null)
            {
                e.PlateNumber = vehicle.PlateNumber;
                e.Brand = vehicle.Brand;
                e.Model = vehicle.Model;
                e.Year = vehicle.Year;
                e.UserId = vehicle.UserId; 

                c.Vehicles.Update(e);
                c.SaveChanges();
            }
        }
    }
}
