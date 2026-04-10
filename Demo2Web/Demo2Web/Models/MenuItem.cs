namespace Demo2Web.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();    
    }
}
