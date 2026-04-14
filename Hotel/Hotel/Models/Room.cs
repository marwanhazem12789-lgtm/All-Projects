using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int 	RoomNumber { get; set; }
        public string 	Type { get; set; }
        public string	Status { get; set; }
        public double 	PricePerNight { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<BookingRecord> Bookings { get; set; } = new List<BookingRecord>();

    }
}
