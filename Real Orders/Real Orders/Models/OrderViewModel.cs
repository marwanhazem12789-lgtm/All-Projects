namespace Real_Orders.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<Customer> customers { get; set; } =  new List<Customer>();
        public int CustomerId { get; set; }

        public List<avvilableproducts> avvilableproducts { get; set; } = new List<avvilableproducts>();
    }



    public class  avvilableproducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

    }
}
