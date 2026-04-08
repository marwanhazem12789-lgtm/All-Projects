using System.ComponentModel.DataAnnotations;

namespace Vechil.Models
{
    public class MaintenanceType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int RecommendedKm { get; set; }

        public List<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    }
}
