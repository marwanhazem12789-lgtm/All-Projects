namespace Libirary_MVC_With_Repo.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();
    }
}
