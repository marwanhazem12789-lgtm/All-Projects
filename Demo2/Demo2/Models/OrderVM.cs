namespace Demo2.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public int Quantity { get; set; }
        public int MenuItemId { get; set; }
        public string Name { get; set; }

    }
}
