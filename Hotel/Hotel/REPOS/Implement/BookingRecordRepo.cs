using Hotel.Models;
using Hotel.REPOS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel.REPOS.Implement
{
    public class BookingRecordRepo : IBookingRecord
    {
        public readonly Context c;
        public BookingRecordRepo(Context c) {
            this.c = c; }

        public void add(BookingRecordVM r)
        {
            var t = new BookingRecord()
            {
                Id = r.Id,
                TotalCost = r.TotalCost,
               RoomId  = r.RoomId,
                UserId = r.UserId,
                ServiceTypeId = r.ServiceTypeId,
                Notes = r.Notes,
            };
            c.bookingRecords.Add(t);
            c.SaveChanges();
        }

        public void Delete(int Id)
        {
            var t = c.bookingRecords.Find(Id);
            if (t != null)
            {
                c.bookingRecords.Remove(t);
                c.SaveChanges();
            }
        }

        public BookingRecord get(int id)
        {
            return c.bookingRecords.Include(c => c.User).Include(c=>c.ServiceType).Include(c => c.Room).FirstOrDefault(r => r.Id == id);
        }

        public List<BookingRecord> Getall()
        {
            return c.bookingRecords.Include(c => c.User).Include(c => c.ServiceType).Include(c => c.Room).ToList();
        }

        public void update(BookingRecordVM record)
        {
            var t = c.bookingRecords.Find(record.Id);
            if (t != null)
            {
                t.TotalCost = record.TotalCost;
                t.UserId = record.UserId;
                t.ServiceTypeId = record.ServiceTypeId;
                t.RoomId = record.RoomId;
                t.Notes = record.Notes;
                c.SaveChanges();
            }
        }
    }
}
