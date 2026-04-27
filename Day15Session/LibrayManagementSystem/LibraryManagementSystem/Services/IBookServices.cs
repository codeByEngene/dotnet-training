namespace LibraryManagementSystem.Services;

public interface IBookServices
{
    void AddBooks(Books books); 
    void EditBooks(Books books);
    void DeleteBooks(int id);
    List<Books> ViewAllBooks();
    List<Books> SearchBook(string searchParam);
}