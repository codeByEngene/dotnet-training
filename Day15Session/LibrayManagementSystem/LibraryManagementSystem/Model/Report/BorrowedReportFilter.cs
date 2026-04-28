namespace LibraryManagementSystem.Model.Report
{
    public class BorrowedReportFilter
    {
        public int MemberId { get; set; } 
        public string BookName { get; set; } 
        public DateOnly FromDate { get; set; } 
        public DateOnly ToDate { get; set; } 
        public string MembershipType { get; set; }
    }
}
