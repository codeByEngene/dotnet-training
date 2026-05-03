using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Repository.BorrowRepository
{
    public interface IBorrowRepository
    {
        void BorrowBook(int bookId, int memberId);
        void DueDateManagement(int bookId, int memberId, DateTime dueDate);
        double BorrowFine(int bookId, int memberId, int noOfDaysExceeded);
        void ReturnBook(int bookId, int memberId);
        List<Borrow> ViewAllBorrowLists();
    }
}
