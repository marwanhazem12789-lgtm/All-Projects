using Hotel.Models;

namespace Hotel.REPOS.Interfaces
{
    public interface IUser
    {
        List<User> users();
        User GetById(int id);
        void Update(User user); 
        void Delete(int id);
        void Add (User user);
    }
}
