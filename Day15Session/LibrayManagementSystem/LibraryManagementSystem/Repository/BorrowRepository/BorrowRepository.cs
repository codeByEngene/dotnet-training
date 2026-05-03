using LibraryManagementSystem.Model;
using System.Text.Json;

namespace LibraryManagementSystem.Repository.BorrowRepository
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly string _connectionString = "../../../Data/borrow.json";

        public void BorrowBook(int bookId, int memberId)
        {
            var borrowDetails = GetAllBorrowsForOperation();

            int maxRecordId = borrowDetails.Any() ? borrowDetails.Max(b => b.RecordId) : 0;

            var newBorrow = new Borrow
            {
                RecordId = maxRecordId + 1,
                BookId = bookId,
                MemberId = memberId,
                IssuedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14), // Assuming a 14-day loan period
                Status = "Borrowed",
                CreatedDate = DateTime.Now,
                // CreatedBy would be set by the user context, not handled here
            };

            borrowDetails.Add(newBorrow);
            var borrowString = JsonSerializer.Serialize(borrowDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, borrowString);
        }

        public void ReturnBook(int bookId, int memberId)
        {
            var borrowDetails = GetAllBorrowsForOperation();
            var borrowToReturn = borrowDetails.FirstOrDefault(b => b.BookId == bookId && b.MemberId == memberId && b.Status == "Borrowed");

            if (borrowToReturn != null)
            {
                borrowToReturn.Status = "Returned";
                borrowToReturn.ReturnedDate = DateTime.Now;
                borrowToReturn.ModifiedDate = DateTime.Now;

                var borrowString = JsonSerializer.Serialize(borrowDetails, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_connectionString, borrowString);
            }
        }

        public void DueDateManagement(int bookId, int memberId, DateTime newDueDate)
        {
            var borrowDetails = GetAllBorrowsForOperation();
            var borrowToUpdate = borrowDetails.FirstOrDefault(b => b.BookId == bookId && b.MemberId == memberId && b.Status == "Borrowed");

            if (borrowToUpdate != null)
            {
                borrowToUpdate.DueDate = newDueDate;
                borrowToUpdate.BookRenewedDate = DateTime.Now;
                borrowToUpdate.ModifiedDate = DateTime.Now;

                var borrowString = JsonSerializer.Serialize(borrowDetails, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_connectionString, borrowString);
            }
        }

        public double BorrowFine(int bookId, int memberId, int noOfDaysExceeded)
        {
            var borrowDetails = GetAllBorrowsForOperation();
            var borrowRecord = borrowDetails.FirstOrDefault(b => b.BookId == bookId && b.MemberId == memberId && b.Status == "Borrowed");

            if (borrowRecord != null)
            {
                double fineRate = 0.50;
                borrowRecord.LateFine = noOfDaysExceeded * fineRate;
                borrowRecord.ModifiedDate = DateTime.Now;

                var borrowString = JsonSerializer.Serialize(borrowDetails, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_connectionString, borrowString);
                return borrowRecord.LateFine;
            }
            return 0;
        }

        private List<Borrow> GetAllBorrowsForOperation()
        {
            if (!File.Exists(_connectionString))
            {
                return new List<Borrow>();
            }

            var borrowFromTable = File.ReadAllText(_connectionString);
            if (string.IsNullOrWhiteSpace(borrowFromTable))
            {
                return new List<Borrow>();
            }

            var borrowDetails = JsonSerializer.Deserialize<List<Borrow>>(borrowFromTable);
            return borrowDetails ?? new List<Borrow>();
        }
    }
}
