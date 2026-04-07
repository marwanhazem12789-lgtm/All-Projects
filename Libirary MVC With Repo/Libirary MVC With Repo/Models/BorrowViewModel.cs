namespace Libirary_MVC_With_Repo.Models
{
    public class BorrowViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateOnly BorrowDate { get; set; }
        public List<Book> Books { get; set; }    = new List<Book>();
        public DateOnly ReturnDate { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public Book Book { get; set; }
        public Member Member { get; set; }
        public string Status { get; set; }

    }
}
