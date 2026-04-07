namespace Libirary_MVC_With_Repo.Models
{
    public class BookRepo : IBook

    {
        public readonly Context c;
        public BookRepo()
        {
            c = new Context();
        }
        public void AddBook(Book book)
        {
            c.Books.Add(book);
            c.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = c.Books.Find(id);
            if (book != null)
            {
                c.Books.Remove(book);
                c.SaveChanges();
            }
        }
        public List<Book> GetAllBooks()
        {
            return c.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            return c.Books.Find(id);
        }
        public void UpdateBook(Book book)
        {
            c.Books.Update(book);
            c.SaveChanges();
        }
    }
}
