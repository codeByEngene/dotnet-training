using LibraryManagementSystem.Learnings.ExplicitImplementation;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repository.BookRepository;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Services.BookService;
using LibraryManagementSystem.Services.BorrowService;
using LibraryManagementSystem.Services.MemberService;
using LibraryManagementSystem.Services.ReportService;

namespace LibraryManagementSystem.MainApplication
{
    public class LmsApp : ILmsApp
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IBorrowService _borrowService;
        private readonly IReportService _reportService;

        private readonly IHello _hello;
        private readonly IHelloWorld _helloWorld;

        public LmsApp(IBookService bookService, IMemberService memberService, IBorrowService borrowService, IReportService reportService, IHello hello, IHelloWorld helloWorld)

        {
            _bookService = bookService;
            _memberService = memberService;
            _borrowService = borrowService;
            _reportService = reportService;
            _hello = hello;
            _helloWorld = helloWorld;
        }

        public void Run()
        {
            var book = new Book
            {
                BookId = 6,
                Name = "Hello World"
            };
            _bookService.EditBooks(book);
            Console.WriteLine("Hello Welcome to the Library Management System!");
        }
    }
}
