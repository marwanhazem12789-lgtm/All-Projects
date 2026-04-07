namespace Libirary_MVC_With_Repo.Models
{
    public interface IBorrow
    {
        List<Borrow> GetAllBorrows();
        Borrow GetBorrowById(int id);
        void AddBorrow(BorrowViewModel borrow);
        void UpdateBorrow(BorrowViewModel borrow);
        void DeleteBorrow(int id);
    }
}