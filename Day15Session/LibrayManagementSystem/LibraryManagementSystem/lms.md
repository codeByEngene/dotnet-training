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
        var shouldContinue = true;

        while (shouldContinue)
        {
            Console.Clear();
            ShowLibraryMenu();

            var choice = (LibraryOption)int.Parse(Console.ReadLine());

            switch (choice)
            {
                case LibraryOption.Book:
                    ShowBookMenu();
                    Console.Write("Press any key to return to the main menu...");
                    Console.ReadLine();
                    break;
                case LibraryOption.Member:
                    break;
                case LibraryOption.Borrow:
                    break;
                case LibraryOption.Exit:
                    shouldContinue = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    Console.Write("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
        // var bookDetails = _bookService.ViewAllBooks();
        // Console.WriteLine("Books in the library:");
        // foreach (var book in bookDetails)
        // {
        //     Console.WriteLine($"ID: {book.BookId}, Title: {book.Name}, Author: {book.Author}");
        // }
    }
    
    private void ShowLibraryMenu()
    {
        Console.WriteLine("=== Welcome To Library Management System ===");
        Console.WriteLine("1. Books Operation");
        Console.WriteLine("2. Members Operation");
        Console.WriteLine("3. Borrow Operation");
        Console.WriteLine("4. Reports");
        Console.WriteLine("0. Exit");
        Console.WriteLine();
    }
    
    private void ShowBookMenu()
    {
        while (true)
        {
            Console.WriteLine("=== Book Operation ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Edit Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            
            var choice = (BookOption)int.Parse(Console.ReadLine());
            switch (choice)
            {
                case BookOption.GetAll:
                    _bookService.ViewAllBooks().ForEach(book =>
                        Console.WriteLine($"ID: {book.BookId}, Title: {book.Name}, Author: {book.Author}"));
                    break;
                case BookOption.Add:
                    Console.Write("Enter book title: ");
                    var title = Console.ReadLine();
                    Console.Write("Enter book author: ");
                    var author = Console.ReadLine();
                    var newBook = new Model.Book { Name = title, Author = author };
                    _bookService.AddBooks(newBook);
                    Console.WriteLine("Book added successfully.");
                    break;
                case 0:
                    return;
            }
        }
        
    }
}







namespace LibraryManagementSystem.Enums;

public enum LibraryOption
{
    Exit = 0,
    Book = 1,
    Member = 2,
    Borrow = 3,
    Report = 4
}

public enum BookOption
{
    Exit = 0,
    Add = 1,
    Edit = 2,
    Delete = 3,
    GetAll = 4,
    Search = 5
}





public class BookRepository : IBookRepository
{
    private readonly string _bookMemory = "../../../Data/books.json";
    public List<Book> GetAllBooks()
    {
        var jsonDetails = File.ReadAllText(_bookMemory);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonDetails);
        return books ?? new List<Book>();
    }

    public void AddBook(Book book)
    {
        var books = GetAllBooks();
        if (books.Any())
        {
            book.BookId = books.Max(b => b.BookId) + 1;
        }
        else
        {
            book.BookId = 1;
        }
        books.Add(book);
        var jsonDetails = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_bookMemory, jsonDetails);
    }
}