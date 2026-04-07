
namespace Libirary_MVC_With_Repo.Models
{
    public class MemberRepo : IMember
    {
        public readonly Context c;
        public MemberRepo()
        {
            c = new Context();
        }
        public void AddMember(Member member)
        {
            c.Members.Add(member);
            c.SaveChanges();

        }

        public void DeleteMember(int id)
        {
            var member = c.Members.Find(id);
            if (member != null)
            {
                c.Members.Remove(member);
                c.SaveChanges();
            }
        }

        public List<Member> GetAllMembers()
        {
            return c.Members.ToList();
        }

        public Member GetMemberById(int id)
        {
            return c.Members.Find(id);
        }

        public void UpdateMember(Member member)
        {
            c.Members.Update(member);
            c.SaveChanges();
        }
    }
}
