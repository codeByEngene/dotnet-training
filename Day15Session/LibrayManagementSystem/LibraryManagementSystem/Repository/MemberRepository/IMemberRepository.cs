using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Repository.MemberRepository
{
    public interface IMemberRepository
    {
        void AddMember(Member member);
        void EditMember(Member member);
        void DeleteMember(int memberId);
        List<Member> ViewAllMembers();
        List<Member> SearchMembers(string searchParam);
        void RenewMembership(Member member);
        
    }
}
