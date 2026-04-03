namespace Real_Orders.Models
{
    public class OrderDetailsViewModel
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderId { get; set; }

        public List<OrderItemDetailsViewModel> OrderItems { get; set; } = new List<OrderItemDetailsViewModel>();


    }



    public class OrderItemDetailsViewModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
