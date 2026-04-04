using System.ComponentModel.DataAnnotations;

namespace Real_Libirary.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string Name { get; set; }
        [EmailAddress]

        public string Email { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
