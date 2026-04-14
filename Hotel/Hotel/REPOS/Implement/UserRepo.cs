using Hotel.Models;
using Hotel.REPOS.Interfaces;

namespace Hotel.REPOS.Implement
{
    public class UserRepo : IUser
    {
        public readonly Context c;
        public UserRepo(Context c)
        {
            this.c = c;
        }


        public void Add(User user)
        {
            c.users.Add(user);
            c.SaveChanges();
        }

        public void Delete(int id)
        {
            var t = c.users.Find(id);
            if (t != null)
            {
                c.users.Remove(t);
                c.SaveChanges();
            }
        }

        public User GetById(int id)
        {
            return c.users.Find(id);
        }

        public void Update(User user)
        {
            c.users.Update(user);
            c.SaveChanges();
        }

        public List<User> users()
        {
            return c.users.ToList();
        }

    }
}
