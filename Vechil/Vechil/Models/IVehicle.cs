namespace Vechil.Models
{
    public interface IVehicle
    {
        List<Vehicle> GetVehicles();
        Vehicle GetVehicleById(int id);
        void AddVehicle(VechailVM vehicle);
        void UpdateVehicle(VechailVM vehicle);
        void DeleteVehicle(int id);
    }
}
