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
                        ShowMemberOperation();
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
                    case "1":
                        Console.WriteLine("Enter book name: ");
                        var bookName = Console.ReadLine();
                        Console.WriteLine("Enter book author: ");
                        var bookAuthor = Console.ReadLine();
                        var newBook = new Book
                        {
                            Name = bookName,
                            Author = bookAuthor,
                        };
                        _bookService.AddBooks(newBook);
                        Console.WriteLine("Book added successfully!");
                        break;
                    case "2":
                        Console.WriteLine("Enter book id for edit: ");
                        var bookId = Console.ReadLine();
                        Console.WriteLine("Enter updated book name: ");
                        var updateBookName = Console.ReadLine();
                        var updatedBookDetails = new Book
                        {
                            BookId = Convert.ToInt32(bookId),
                            Name = updateBookName
                        };
                        _bookService.EditBooks(updatedBookDetails);
                        Console.Clear();
                        Console.WriteLine("Book updated successfully!");
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case"3":
                        Console.WriteLine("Enter book id for delete: ");
                        var deleteBookId = Console.ReadLine();
                        _bookService.DeleteBooks(Convert.ToInt32(deleteBookId));
                        Console.Clear();
                        Console.WriteLine("Book deleted successfully!");
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Enter book name for search: ");
                        var searchBookName = Console.ReadLine();
                        var searchBookList = _bookService.SearchBook(searchBookName);
                        if(searchBookList.Count>0)
                        {
                            foreach (var book in searchBookList)
                            {
                                Console.WriteLine($"Book Id : {book.BookId} | Book Name : {book.Name}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No book found with the given name!");
                        }
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case "5":
                        Console.Clear();
                        var bookList = _bookService.ViewAllBooks();
                        foreach (var book in bookList)
                        {
                            Console.WriteLine($"Book Id : {book.BookId} | Book Name : {book.Name}");
                        }
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Exiting Book Operations...\n\n\n");
                        return;
                    default:
                        Console.WriteLine("Invalid sub menu!");
                        break;
                }
            }
        }
        
        private void ShowMemberOperation()
        {
            while(true)
            {
                Console.WriteLine("--------SUB MENU-------");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Edit Member");
                Console.WriteLine("3. Delete Member");
                Console.WriteLine("4. Search Members");
                Console.WriteLine("5. View All Members");
                Console.WriteLine("6. Renew Membership");
                Console.WriteLine("0. Exit");
                Console.WriteLine("/***************************************************/");
                Console.WriteLine("Please select a menu to proceed: ");
                var operationMethodChoice = Console.ReadLine();
                switch (operationMethodChoice)
                {
                    case "1":
                        Console.WriteLine("Enter member name: ");
                        var memberName = Console.ReadLine();
                        Console.WriteLine("Enter member's phone number: ");
                        var phoneNo = Console.ReadLine();
                        var newMember = new Member
                        {
                            MemberName = memberName,
                            Phone = phoneNo,
                        };
                        _memberService.AddMember(newMember);
                        Console.WriteLine("Member added successfully!");
                        break;
                    case "2":
                        Console.WriteLine("Enter member id for edit: ");
                        var memberId = Console.ReadLine();
                        Console.WriteLine("Enter updated member name: ");
                        var updateMemberName = Console.ReadLine();
                        var updatedMemberDetails = new Member
                        {
                            MemberId = Convert.ToInt32(memberId),
                            MemberName = updateMemberName
                        };
                        _memberService.EditMember(updatedMemberDetails);
                        Console.Clear();
                        Console.WriteLine("Member details updated successfully!");
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case"3":
                        Console.WriteLine("Enter membership id for delete: ");
                        var deleteMemberId = Console.ReadLine();
                        _memberService.DeleteMember(Convert.ToInt32(deleteMemberId));
                        Console.Clear();
                        Console.WriteLine("Member deleted successfully!");
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Enter member name for search: ");
                        var searchMemberName = Console.ReadLine();
                        var searchMemberList = _memberService.SearchMembers(searchMemberName);
                        if(searchMemberList.Count>0)
                        {
                            foreach (var member in searchMemberList)
                            {
                                Console.WriteLine($"Member Id : {member.MemberId} | Member Name : {member.MemberName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No member found with the given name!");
                        }
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case "5":
                        Console.Clear();
                        var memberList = _memberService.ViewAllMembers();
                        foreach (var member in memberList)
                        {
                            Console.WriteLine($"Member Id : {member.MemberId} | Member Name : {member.MemberName}");
                        }
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case "6":
                        Console.WriteLine("Enter membership id for membership renew: ");
                        var renewMemberId = Console.ReadLine();
                        Member renewMember = new Member
                        {
                            MemberId = Convert.ToInt32(renewMemberId)
                        };
                        _memberService.RenewMembership(renewMember);
                        Console.Clear();
                        Console.WriteLine("Membership renewed successfully!");
                        Console.WriteLine("/**********************************************/\n\n");
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Exiting Member Operations...\n\n\n");
                        return;
                    default:
                        Console.WriteLine("Invalid sub menu!");
                        break;
                }
            }
        }
    }
}
