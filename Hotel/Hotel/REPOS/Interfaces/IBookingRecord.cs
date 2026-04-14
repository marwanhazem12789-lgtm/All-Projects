using Hotel.Models;

namespace Hotel.REPOS.Interfaces
{
    public interface IBookingRecord
    {
        List<BookingRecord> Getall();
        BookingRecord get(int id);
        void add(BookingRecordVM record); 
        void Delete(int Id);
        void update(BookingRecordVM record);
    }
}
