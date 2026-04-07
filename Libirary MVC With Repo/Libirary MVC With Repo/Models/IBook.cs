namespace Libirary_MVC_With_Repo.Models
{
    public interface IBook
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);

    }
}
