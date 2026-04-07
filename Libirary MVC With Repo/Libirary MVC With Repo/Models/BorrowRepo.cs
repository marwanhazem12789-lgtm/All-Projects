using Microsoft.EntityFrameworkCore;

namespace Libirary_MVC_With_Repo.Models
{
    public class BorrowRepo : IBorrow
    {
        public readonly Context c;
        public BorrowRepo()
        {
            c = new Context();
        }
        public void AddBorrow(BorrowViewModel borrow)
        {
            var book = c.Books.Find(borrow.BookId);

            if (book != null && book.AvailableCopies > 0)
            {
                var newBorrow = new Borrow
                {
                    BorrowDate = borrow.BorrowDate,
                    ReturnDate = borrow.ReturnDate,
                    Status = borrow.Status ?? "Borrowed",
                    BookId = borrow.BookId,
                    MemberId = borrow.MemberId
                };

                book.AvailableCopies--; 

                c.Borrows.Add(newBorrow);
                c.SaveChanges();
            }
        }
        public void DeleteBorrow(int id)
        {
            var borrow = c.Borrows.Find(id);
            if (borrow != null)
            {
                c.Borrows.Remove(borrow);
                c.SaveChanges();
            }
        }
        public List<Borrow> GetAllBorrows()
        {
            return c.Borrows.Include(a => a.Book).Include(a => a.Member).ToList();
        }
        public Borrow GetBorrowById(int id)
        {
            return c.Borrows
                    .Include(b => b.Book)
                    .Include(b => b.Member)
                    .FirstOrDefault(b => b.Id == id); 
        }
        public void UpdateBorrow(BorrowViewModel borrow)
        {
            var existingBorrow = c.Borrows.Find(borrow.Id);
            if (existingBorrow != null)
            {
                    existingBorrow.Status = borrow.Status;
                existingBorrow.BookId = borrow.BookId;
                existingBorrow.MemberId = borrow.MemberId;
                existingBorrow.BorrowDate = borrow.BorrowDate;
                existingBorrow.ReturnDate = borrow.ReturnDate;
                c.SaveChanges();
            }
        }
    }
}
