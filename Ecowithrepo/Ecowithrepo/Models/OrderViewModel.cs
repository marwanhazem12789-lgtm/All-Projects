namespace Ecowithrepo.Models
{
    
    public class OrderViewModel
    {
        public int SelectedCustomerId { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<ProductSelectionViewModel> Products { get; set; } = new List<ProductSelectionViewModel>();
    }

    public class ProductSelectionViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } 
    }

    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<OrderItemInfo> Items { get; set; }
    }

    public class OrderItemInfo
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
