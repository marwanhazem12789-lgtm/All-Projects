namespace Demo2Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem menuItem { get; set; }
        public int Quantity { get; set; }
        public DateOnly OrderDate { get; set; }
    }
}
