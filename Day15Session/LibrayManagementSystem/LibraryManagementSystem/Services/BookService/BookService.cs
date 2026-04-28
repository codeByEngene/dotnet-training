using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Services.BookService;

/// <summary>
/// Provides operations for managing books, including adding, editing, deleting, viewing, and searching book records.
/// </summary>
/// <remarks>This service defines the contract for book management functionality in the application.
/// Implementations are responsible for handling the underlying data storage and retrieval. Thread safety and
/// performance characteristics depend on the specific implementation.</remarks>
public class BookService : IBookService
{
    /// <summary>
    /// Adds a book to the collection.
    /// </summary>
    /// <param name="books">The book to add to the collection. Cannot be null.</param>
    public void AddBooks(Book books)
    {
        Console.Write("hello");
    }

    public void EditBooks(Book books)
    {
        throw new NotImplementedException();
    }

    public void DeleteBooks(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves a list of all books available in the collection.
    /// </summary>
    /// <returns>A list of <see cref="Book"/> objects representing all books. The list is empty if no books are available.</returns>
    public List<Book> ViewAllBooks()
    {
        throw new NotImplementedException();
    }

    public List<Book> SearchBook(string searchParam)
    {
        throw new NotImplementedException();
    }
}