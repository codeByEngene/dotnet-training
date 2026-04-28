using LibraryManagementSystem.Model.Report;

namespace LibraryManagementSystem.Services.ReportService
{
    public interface IReportService
    {
        List<BorrowedReport> GetCurrentlyBorrowedBooksReport(BorrowedReportFilter borrowedReportFilter);
        void GetOverDueBooksReport();
        void HistoryOfStudentsReport();
    }
}
