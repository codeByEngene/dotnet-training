using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Repository;

public interface IBookRepository
{
    List<Book> GetAllBooks();
    void AddBook(Book book);
}