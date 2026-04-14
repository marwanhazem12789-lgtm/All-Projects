using System.ComponentModel.DataAnnotations;

namespace Demo2.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
