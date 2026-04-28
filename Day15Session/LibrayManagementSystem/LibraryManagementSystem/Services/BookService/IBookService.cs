using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Services.BookService;

/// <summary>
/// Defines a contract for managing book records, including operations to add, edit, delete, view, and search for books.
/// </summary>
/// <remarks>Implementations of this interface provide methods for basic CRUD (Create, Read, Update, Delete)
/// operations on book entities. The interface is intended to abstract the underlying data storage or retrieval
/// mechanism, allowing consumers to interact with book data in a consistent manner.</remarks>
public interface IBookService
{
    void AddBooks(Book books); 
    void EditBooks(Book books);
    void DeleteBooks(int id);
    List<Book> ViewAllBooks();
    List<Book> SearchBook(string searchParam);
}