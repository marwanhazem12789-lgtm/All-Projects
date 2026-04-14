using Hotel.Models;

namespace Hotel.REPOS.Interfaces
{
    public interface IRoom
    {
        List<Room> rooms();
        void add(RoomVM r);
        void Update(RoomVM r);
        void delete(int r);
        Room Get(int id);
    }
}
