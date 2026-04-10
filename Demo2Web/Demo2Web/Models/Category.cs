using System.ComponentModel.DataAnnotations;

namespace Demo2Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }   = new List<MenuItem>();
    }
}
