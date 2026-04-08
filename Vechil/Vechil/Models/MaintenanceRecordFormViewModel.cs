using System.ComponentModel.DataAnnotations;

namespace Vechil.Models
{
    public class MaintenanceRecordFormViewModel
    {
        public int? Id { get; set; } 

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int MaintenanceTypeId { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; } = DateTime.Now;

        public int CurrentKm { get; set; }
        public string Notes { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<MaintenanceType> MaintenanceTypes { get; set; } =   new List<MaintenanceType>();
        public Vehicle Vechil { get; set; }
        public MaintenanceType Maintenance { get; set; }

    }
}