using LibraryManagementSystem.Model.Shared;

namespace LibraryManagementSystem.Model;

public class Borrow : LmsShared
{
    public int BookId { get; set; }
    public int RecordId { get; set; }
    public int MemberId { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public double LateFine { get; set; }
    public DateTime ReturnedDate { get; set; }
    public string Status { get; set; }
    public DateTime BookRenewedDate { get; set; }
    public string ReceivedBy { get; set; }
    public string Remarks { get; set; }
}