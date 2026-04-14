namespace Hotel.Models
{
    public class RoomVM
    {
        public List<User> Users { get; set; } = new List<User>();
        public int Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public double PricePerNight { get; set; }
        public int UserId { get; set; }
        public int RoomNumber { get; set; }
        public User User { get; set; }

    }
}
