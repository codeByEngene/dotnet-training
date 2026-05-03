using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repository.MemberRepository;

namespace LibraryManagementSystem.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly MemberRepository _memberRepository = new MemberRepository();

        public void AddMember(Member member)
        {
            _memberRepository.AddMember(member);
        }

        public void DeleteMember(int memberId)
        {
            _memberRepository.DeleteMember(memberId);
        }

        public void EditMember(Member member)
        {
            _memberRepository.EditMember(member);
        }

        public void RenewMembership(Member member)
        {
            member.ExpirationDate = DateTime.Now.AddDays(90);
            member.ModifiedBy = "admin";
            member.ModifiedDate = DateTime.Now;
            _memberRepository.RenewMembership(member);
        }

        public List<Member> SearchMembers(string searchParam)
        {
            return _memberRepository.SearchMembers(searchParam);
        }

        public List<Member> ViewAllMembers()
        {
            return _memberRepository.ViewAllMembers();
        }
    }
}
