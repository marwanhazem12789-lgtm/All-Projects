using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class BookingRecordVM
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }

        public int RoomId { get; set; }

        public int UserId { get; set; }
        public int ServiceTypeId { get; set; }

        public string Notes { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<User> Users { get; set; } = new List<User>();
        public List<ServiceType> ServiceTypes { get; set; } = new List<ServiceType>();

        public User User { get; set; }
        public Room Room { get; set; }
        public ServiceType ServiceType { get; set; }

    }
}
