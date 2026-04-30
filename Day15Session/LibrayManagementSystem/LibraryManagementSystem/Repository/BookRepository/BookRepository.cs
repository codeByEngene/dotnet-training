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

        public void DeleteBook(int id)
        {
            var bookDetails = GetAllBooksForOperation(); bookDetails.RemoveAll(b => b.BookId == id);
            var bookString = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, bookString);
        }

        public void EditBook(Book book)
        {
            var bookDetails = GetAllBooksForOperation();
            var bookToEdit = bookDetails.FirstOrDefault(b => b.BookId == book.BookId);
            bookToEdit?.Name = book.Name;
            bookToEdit?.ModifiedDate = book.ModifiedDate;
            bookToEdit?.ModifiedBy = book.ModifiedBy;
            var bookStringUpdated = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, bookStringUpdated);
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
            var bookFromTable = File.ReadAllText(_connectionString);
            var bookDetails = JsonSerializer.Deserialize<List<Book>>(bookFromTable);
            return bookDetails ?? new List<Book>();
        }
    }
}





//
// var result = (
//     from c in customers
//     join o in orders on c.Id equals o.CustomerId
//     join p in payments on o.Id equals p.OrderId
//     select new
//     {
//         c.Name,
//         o.Id,
//         p.Amount
//     }
// ).ToList();