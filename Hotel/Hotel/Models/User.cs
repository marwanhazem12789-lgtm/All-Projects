using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Range(8, int.MaxValue)]
        public string Password { get; set; }
        [Range(1 , 11)] // leanght
        public string PhoneNumber { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<BookingRecord> BookingRecords { get; set; } = new List<BookingRecord>();
        public List<ServiceType> ServiceTypes { get; set; } = new List<ServiceType>();
    }
}
