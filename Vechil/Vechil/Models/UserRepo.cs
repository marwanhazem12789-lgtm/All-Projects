namespace Vechil.Models
{
    public class UserRepo : IUser
    {
        public readonly Context c;
        public UserRepo()
        {
            c = new Context();

        }

        public void AddUser(User user)
        {
            c.Users.Add(user);
            c.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = c.Users.Find(id);
            if (user != null)
            {
                c.Users.Remove(user);
                c.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            return c.Users.Find(id);
        }

        public List<User> GetUsers()
        {
            return c.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            c.Users.Update(user);
            c.SaveChanges();
        }
    }
}
