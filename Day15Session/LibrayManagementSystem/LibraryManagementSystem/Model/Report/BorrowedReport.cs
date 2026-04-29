using System.Runtime.CompilerServices;

namespace LibraryManagementSystem.Model.Report
{
    /// <summary>
    /// Represents a borrowed books report containing member information and details of books they have currently borrowed.
    /// </summary>
    /// <remarks>This class is used to generate reports showing all books currently borrowed by a member,
    /// including issuance dates, due dates, and calculated fines for overdue items.</remarks>
    public class BorrowedReport
    {
        /// <summary>
        /// Gets or sets the name of the member borrowing the books.
        /// </summary>
        public string MemberName { get; set; }
        
        /// <summary>
        /// Gets or sets the phone number of the member.
        /// </summary>
        public string MemberPhoneNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the membership type of the member (e.g., Standard, Premium, Student).
        /// </summary>
        public string MembershipType { get; set; }
        
        /// <summary>
        /// Gets or sets the list of book details currently borrowed by this member.
        /// </summary>
        public List<BorrowedBookDetail> BorrowedBookDetails { get; set; }
    }

    /// <summary>
    /// Represents detailed information about a book that has been borrowed by a member.
    /// </summary>
    /// <remarks>This class contains specific details about a borrowed book including dates, due dates, and any applicable fines.</remarks>
    public class BorrowedBookDetail
    {
        /// <summary>
        /// Gets or sets the name or title of the borrowed book.
        /// </summary>
        public string BookName { get; set; }
        
        /// <summary>
        /// Gets or sets the ISBN (International Standard Book Number) of the borrowed book.
        /// </summary>
        public string BookIsbn { get; set; }
        
        /// <summary>
        /// Gets or sets the date when the book was issued to the member.
        /// </summary>
        public DateTime IssuedDate { get; set; }
        
        /// <summary>
        /// Gets or sets the expected due date for returning the book.
        /// </summary>
        public DateTime DueDate { get; set; }
        
        /// <summary>
        /// Gets or sets the number of days remaining until the book is due (negative if overdue).
        /// </summary>
        public int DueDays { get; set; }
        
        /// <summary>
        /// Gets or sets the calculated fine amount for overdue return.
        /// </summary>
        public double DueFine { get; set; }
    }
}


//[
//  {
//    "memberName": "rashik",
//    "memberPhoneNumber": "9841840193",
//    "membershipType": "hello",
//    "borrowedBookDetails": [
//      {
//        "bookName": "b1",
//        "bookIsbn": "567890"
//      },
//      {
//    "bookName": "b2",
//        "bookIsbn": "5678901"
//      }
//    ]
//  },
//  {
//    "memberName": "rashik",
//    "memberPhoneNumber": "9841840193",
//    "membershipType": "hello",
//    "borrowedBookDetails": [
//      {
//        "bookName": "b1",
//        "bookIsbn": "567890"
//      },
//      {
//        "bookName": "b2",
//        "bookIsbn": "5678901"
//      }
//    ]
//  }
//]