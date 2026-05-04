using LibraryManagementSystem.Model;
using LibraryManagementSystem.Model.Report;
using LibraryManagementSystem.Repository.BookRepository;
using LibraryManagementSystem.Repository.BorrowRepository;
using LibraryManagementSystem.Repository.MemberRepository;

namespace LibraryManagementSystem.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowRepository _borrowRepository;
        private readonly IMemberRepository _memberRepository;

        public ReportService(IBookRepository bookRepository, IBorrowRepository borrowRepository, IMemberRepository memberRepository)
        {
            _bookRepository = bookRepository;
            _borrowRepository = borrowRepository;
            _memberRepository = memberRepository;
        }

        public List<Borrow> GetCurrentlyBorrowedBooksReport(BorrowedReportFilter borrowedReportFilter)
        {
            List<Borrow> borrowList = new List<Borrow>();
            var borrowedBooks = _borrowRepository.ViewAllBorrowLists();
            var borrowDetails = borrowedBooks.Where(x => x.MemberId == borrowedReportFilter.MemberId).ToList();
            borrowList.AddRange(borrowDetails);
            return borrowList;
        }

        public List<DueDateReport> GetOverDueBooksReport(DateOnly currentDate)
        {
            throw new NotImplementedException();
        }

        public List<MemberHistoryReport> MemberHistoryReport(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
