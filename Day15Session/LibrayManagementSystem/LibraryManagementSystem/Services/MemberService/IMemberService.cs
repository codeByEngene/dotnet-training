using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Services.MemberService
{
    public interface IMemberService
    {
        void AddMembers(Member member);
        void EditMembers(Member member);
        void DeleteMembers(int memberId);
        List<Member> ViewAllMembers();
        List<Member> SearchMember();
        void RenewMembership(Member member);
        
    }
}
