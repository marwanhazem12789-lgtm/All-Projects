
namespace Real_Libirary.Models
{
    public class VM
    {
        public Customer SingleCustomer { get; set; }
        public Book SingleBook { get; set; }
        public int Id { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public int CustomerId { get; set; }
            public int BookId { get; set; }
       public DateTime OrderDate { get; set; }
    }
}
