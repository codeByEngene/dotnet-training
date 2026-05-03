namespace LibraryManagementSystem.Services.BorrowService
{
    public interface IBorrowService
    {
        bool BorrowBook(int bookId, int memberId);
        double BorrowFine(int bookId, int memberId);
        void DueDateManagement(int bookId, int memberId, DateTime dueDate);
        void ReturnBook(int bookId, int memberId);
    }
}
