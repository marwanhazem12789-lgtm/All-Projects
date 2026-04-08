namespace Vechil.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
