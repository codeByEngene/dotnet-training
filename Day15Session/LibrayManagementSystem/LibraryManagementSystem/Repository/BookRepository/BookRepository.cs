using LibraryManagementSystem.Model;
using System.Text.Json;

namespace LibraryManagementSystem.Repository.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString = "../../../Data/book.json";
        public void AddBook(Book book)
        {
            var bookDetails = GetAllBooksForOperation();

            int bookMaxId = bookDetails.Max(b => b.BookId);
            book.BookId = bookMaxId + 1;

            bookDetails.Add(book);
            var bookString = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, bookString);
        }

        public bool DeleteBook(int id)
        {
            var bookDetails = GetAllBooksForOperation();
            var bookToDelete = bookDetails.FirstOrDefault(b => b.BookId == id);
            if (bookToDelete == null)
            {
                return false;
            }
            bookDetails.RemoveAll(b => b.BookId == id);
            var bookString = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, bookString);
            return true;
        }

        public bool EditBook(Book book)
        {
            var bookDetails = GetAllBooksForOperation();
            var bookToEdit = bookDetails.FirstOrDefault(b => b.BookId == book.BookId);
            if (bookToEdit == null)
            {
                return false;
            }
            else
            {
                bookToEdit.Name = book.Name;
                bookToEdit.ModifiedDate = book.ModifiedDate;
                bookToEdit.ModifiedBy = book.ModifiedBy;
                var bookStringUpdated = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_connectionString, bookStringUpdated);
                return true;
            }
        }

        public bool UpdateBookCount(Book book)
        {
            var bookDetails = GetAllBooksForOperation();
            var bookToEdit = bookDetails.FirstOrDefault(b => b.BookId == book.BookId);
            if (bookToEdit == null)
            {
                return false;
            }
            else
            {
                bookToEdit.AvailableCopies = book.AvailableCopies;
                bookToEdit.ModifiedDate = book.ModifiedDate;
                bookToEdit.ModifiedBy = book.ModifiedBy;
                var bookStringUpdated = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_connectionString, bookStringUpdated);
                return true;
            }
        }

        public List<Book> SearchBooks(string searchParam)
        {
            var bookDetails = GetAllBooksForOperation();
            var searchedDetails = bookDetails.Where(x=> x.Name.Contains(searchParam, StringComparison.OrdinalIgnoreCase)).ToList();
            return searchedDetails;
        }

        public List<Book> ViewAllBooks()
        {
            return GetAllBooksForOperation(); 
        }


        private List<Book> GetAllBooksForOperation()
        {
            if (!File.Exists(_connectionString))
            {
                return new List<Book>();
            }
            var bookFromTable = File.ReadAllText(_connectionString);
            var bookDetails = JsonSerializer.Deserialize<List<Book>>(bookFromTable);
            return bookDetails ?? new List<Book>();
        }
    }
}