using System.ComponentModel.DataAnnotations;

namespace Real_Libirary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Range(10, 1000)]
        public decimal Price { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
