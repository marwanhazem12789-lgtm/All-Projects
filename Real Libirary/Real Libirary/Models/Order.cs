using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Real_Libirary.Models
{
    public class Order
    {
        [Key]

        public int Id { get; set; }
        [Required]

        public int   CustomerId { get; set; }
        [ForeignKey("Customer")]

        public int BookId { get; set; }
        [ForeignKey("Book")]


        [DataType(DataType.Date)]

        public DateTime
OrderDate
        { get; set; }

        public Customer Customer { get; set; }
        public Book Book { get; set; }

    }
}
