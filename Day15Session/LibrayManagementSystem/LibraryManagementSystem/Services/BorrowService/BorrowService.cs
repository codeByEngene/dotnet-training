namespace LibraryManagementSystem.Services.BorrowService
{
    public class BorrowService : IBorrowService
    {
        public void BorrowBook(int bookId, int memberId)
        {
            throw new NotImplementedException();
        }

        public double BorrowFine(int bookId, int memberId, int noOfDaysExceeded)
        {
            throw new NotImplementedException();
        }

        public void DueDateManagement(int bookId, int memberId, DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(int bookId, int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
