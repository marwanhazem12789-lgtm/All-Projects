namespace Demo2Web.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public int Quantity { get; set; }
        public MenuItem menuItem { get; set; }
    }
}
