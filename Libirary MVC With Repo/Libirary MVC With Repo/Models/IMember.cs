namespace Libirary_MVC_With_Repo.Models
{
    public interface IMember
    {
        List<Member> GetAllMembers();
            Member GetMemberById(int id);
            void AddMember(Member member);
            void UpdateMember(Member member);
            void DeleteMember(int id);
    }
}
