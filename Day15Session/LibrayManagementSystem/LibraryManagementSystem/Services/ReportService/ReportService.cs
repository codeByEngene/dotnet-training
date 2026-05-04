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

        public List<BorrowedReport> GetBorrowedBooksReport(BorrowedReportFilter borrowedReportFilter)
        {
            List<BorrowedReport> borrowedReports = new List<BorrowedReport>();
            var borrowedBooks = _borrowRepository.ViewAllBorrowLists();
            var memberDetails = _memberRepository.ViewAllMembers();
            var bookDetails = _bookRepository.ViewAllBooks();
            var response = (
                    from b in borrowedBooks
                    join m in memberDetails on b.MemberId equals m.MemberId
                    select new
                    {
                        m.MemberId,
                        m.MemberName,
                        m.MembershipType,
                        m.Phone
                    }
                ).ToList();

            foreach(var details in response.Distinct())
            {
                List<BorrowedBookDetail> borrowedBookDetails = new List<BorrowedBookDetail>();
                var memberWiseBookDetails = borrowedBooks.Where(x => x.MemberId == details.MemberId).Select(x=>x.BookId).ToList();

                //var bookName = (
                //   from b in bookDetails
                //   join bb in borrowedBooks on b.BookId equals bb.BookId
                //   select new
                //   {
                //       bb.BookId,
                //       b.Name
                //   }).ToList();

                foreach (var bookId in memberWiseBookDetails)
                {
                    borrowedBookDetails.Add(new BorrowedBookDetail
                    {
                        BookId = bookId,
                        BookName = bookDetails.Where(x => x.BookId == bookId).Select(x => x.Name).FirstOrDefault(),
                        BookIsbn = bookDetails.Where(x => x.BookId == bookId).Select(x => x.Isbn).FirstOrDefault()
                    });
                }


                BorrowedReport report = new BorrowedReport
                {
                    MemberName = details.MemberName,
                    MembershipType = details.MembershipType,
                    MemberPhoneNumber = details.Phone,
                    BorrowedBookDetails = borrowedBookDetails
                };
                borrowedReports.Add(report);
            }
            return borrowedReports;
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
