using System.ComponentModel.DataAnnotations;

namespace Demo2.Models
{
    public class Order
    {
        [Key]
       public int Id { get; set; }
        public DateOnly OrderDate   { get; set; }
        public int 	Quantity { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
