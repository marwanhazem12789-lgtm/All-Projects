using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vechil.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    
}
}
