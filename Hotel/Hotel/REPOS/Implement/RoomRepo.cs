using Hotel.Models;
using Hotel.REPOS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel.REPOS.Implement
{
    public class RoomRepo : IRoom
    {
        public readonly Context c;
        public RoomRepo(Context c)
        {
            this.c = c;
        }

        public void add(RoomVM r)
        {
            var t = new Room()
            {
                Id = r.Id,
                Status = r.Status,
                UserId = r.UserId,
                Type = r.Type,
                PricePerNight = r.PricePerNight,
                RoomNumber = r.RoomNumber,

            };
            c.Rooms.Add(t);
            c.SaveChanges();
        }

        public void delete(int r)
        {
            var t = c.Rooms.Find(r);
            if (t != null)
            {
                c.Rooms.Remove(t);
                c.SaveChanges();
            }
        }

        public Room Get(int id)
        {
            return c.Rooms.Include(r => r.User).FirstOrDefault(i => i.Id == id);
        }

        public List<Room> rooms()
        {
            return c.Rooms.Include( o => o.User).ToList(); 
        }

        public void Update(RoomVM r)
        {
            var t = c.Rooms.Find(r.Id);
            if (t != null)
            {
                t.Status = r.Status;
                t.UserId = r.UserId;
                c.Rooms.Update(t);
                c.SaveChanges();
            }

        }
    }
}
