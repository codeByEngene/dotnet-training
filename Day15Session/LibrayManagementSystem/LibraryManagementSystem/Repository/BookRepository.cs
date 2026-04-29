using LibraryManagementSystem.Model;
using System.Text.Json;

namespace LibraryManagementSystem.Repository;

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