using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libirary_MVC_With_Repo.Models
{
    public class Borrow
    {
        public int Id { get; set; }
        public DateOnly BorrowDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public string Status { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }


        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
