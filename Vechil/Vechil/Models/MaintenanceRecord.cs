using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vechil.Models
{
    public class MaintenanceRecord
    {
        public int Id { get; set; }

        [Required, DataType(DataType.Date)]

        public int CurrentKm { get; set; }

        public string Notes { get; set; }

        public DateTime ServiceDate { get; set; }
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public int MaintenanceTypeId { get; set; }
        [ForeignKey("MaintenanceTypeId")]
        public MaintenanceType MaintenanceType { get; set; }
    }
}
