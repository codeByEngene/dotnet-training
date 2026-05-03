using LibraryManagementSystem.Model;
using System.Text.Json;

namespace LibraryManagementSystem.Repository.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectionString = "../../../Data/member.json";

        public void AddMember(Member member)
        {
            var memberDetails = GetAllMembersForOperation();

            int memberMaxId = memberDetails.Any() ? memberDetails.Max(m => m.MemberId) : 0;
            member.MemberId = memberMaxId + 1;

            memberDetails.Add(member);
            var memberString = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, memberString);
        }

        public void DeleteMember(int memberId)
        {
            var memberDetails = GetAllMembersForOperation();
            memberDetails.RemoveAll(m => m.MemberId == memberId);
            var memberString = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, memberString);
        }

        public void EditMember(Member member)
        {
            var memberDetails = GetAllMembersForOperation();
            var memberToEdit = memberDetails.FirstOrDefault(m => m.MemberId == member.MemberId);
            
            if (memberToEdit != null)
            {
                memberToEdit.MemberName = member.MemberName;
                memberToEdit.Phone = member.Phone;
                memberToEdit.Address = member.Address;
                memberToEdit.Email = member.Email;
                memberToEdit.MembershipType = member.MembershipType;
                memberToEdit.Status = member.Status;
                memberToEdit.ModifiedDate = member.ModifiedDate;
                memberToEdit.ModifiedBy = member.ModifiedBy;
                
                var memberStringUpdated = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_connectionString, memberStringUpdated);
            }
        }

        public void RenewMembership(Member member)
        {
            var memberDetails = GetAllMembersForOperation();
            var memberToRenew = memberDetails.FirstOrDefault(m => m.MemberId == member.MemberId);
            if (memberToRenew != null)
            {
                memberToRenew.ExpirationDate = member.ExpirationDate;
                memberToRenew.Status = member.Status;
                memberToRenew.ModifiedDate = member.ModifiedDate;
                memberToRenew.ModifiedBy = member.ModifiedBy;
                var memberStringUpdated = JsonSerializer.Serialize(memberDetails, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_connectionString, memberStringUpdated);
            }
        }

        public List<Member> SearchMembers(string searchParam)
        {
            var memberDetails = GetAllMembersForOperation();
            var searchedDetails = memberDetails.Where(x => 
                x.MemberName.Contains(searchParam, StringComparison.OrdinalIgnoreCase)
            ).ToList();
            return searchedDetails;
        }

        public List<Member> ViewAllMembers()
        {
            return GetAllMembersForOperation();
        }

        private List<Member> GetAllMembersForOperation()
        {
            if (!File.Exists(_connectionString))
            {
                return new List<Member>();
            }

            var memberFromTable = File.ReadAllText(_connectionString);
            if (string.IsNullOrWhiteSpace(memberFromTable))
            {
                return new List<Member>();
            }

            var memberDetails = JsonSerializer.Deserialize<List<Member>>(memberFromTable);
            return memberDetails ?? new List<Member>();
        }
    }
}
