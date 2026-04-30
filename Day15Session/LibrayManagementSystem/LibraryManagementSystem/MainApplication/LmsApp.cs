using LibraryManagementSystem.Learnings.ExplicitImplementation;
using LibraryManagementSystem.Model;
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


        public LmsApp(IBookService bookService, IMemberService memberService, IBorrowService borrowService, IReportService reportService)

        {
            _bookService = bookService;
            _memberService = memberService;
            _borrowService = borrowService;
            _reportService = reportService;
        }

        public void Run()
        {
            Console.WriteLine("Hello Welcome to the Library Management System!");
            bool exitRequested = false;
            while (!exitRequested)
            {
                ShowMenu();
                Console.WriteLine("Please select a menu to proceed: ");
                var operationChoice = Console.ReadLine();
                switch (operationChoice)
                {
                    case "1":
                        ShowBookOperation();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        exitRequested = true;
                        Console.WriteLine("You have exited the system!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("/***************************************************/");
            Console.WriteLine("--------MENU-------");
            Console.WriteLine("1. Book Operations");
            Console.WriteLine("2. Member Operations");
            Console.WriteLine("3. Borrow Operations");
            Console.WriteLine("4. Report Operations");
            Console.WriteLine("0. Exit");
            Console.WriteLine("/***************************************************/");

        }

        private void ShowBookOperation()
        {
            while(true)
            {
                Console.WriteLine("--------SUB MENU-------");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Edit Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. View All Books");
                Console.WriteLine("0. Exit");
                Console.WriteLine("/***************************************************/");
                Console.WriteLine("Please select a menu to proceed: ");
                var operationMethodChoice = Console.ReadLine();
                switch (operationMethodChoice)
                {
                    case "5":
                        var bookList = _bookService.ViewAllBooks();
                        foreach (var book in bookList)
                        {
                            Console.WriteLine(book.Name);
                        }
                        break;
                    case "0":
                        Console.WriteLine("Exiting Book Operations...");
                        return;
                    default:
                        Console.WriteLine("Invalid sub menu!");
                        break;
                }
            }
            

        }
    }
}
