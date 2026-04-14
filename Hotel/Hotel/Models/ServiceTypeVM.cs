namespace Hotel.Models
{
    public class ServiceTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<User> users {  get; set; } = new List<User>();
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
