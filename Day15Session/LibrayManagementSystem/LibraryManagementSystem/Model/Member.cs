using LibraryManagementSystem.Model.Shared;

namespace LibraryManagementSystem.Model;

public class Member : LmsShared
{
    public int MemberId { get; set; }
    public string MemberName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public DateTime JoinedDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string MembershipType { get; set; }
    public string Status { get; set; }
}