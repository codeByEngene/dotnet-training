using LibraryManagementSystem.Model;
using LibraryManagementSystem.Model.Report;

namespace LibraryManagementSystem.Services.ReportService
{
    public interface IReportService
    {
        List<Borrow> GetCurrentlyBorrowedBooksReport(BorrowedReportFilter borrowedReportFilter);
        List<DueDateReport> GetOverDueBooksReport(DateOnly currentDate);
        List<MemberHistoryReport> MemberHistoryReport(int memberId);
    }
}
