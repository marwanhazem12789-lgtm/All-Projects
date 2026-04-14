using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<BookingRecord> Bookings { get; set; } = new List<BookingRecord>();
    }
}
