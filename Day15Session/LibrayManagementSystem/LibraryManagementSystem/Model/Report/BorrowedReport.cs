namespace LibraryManagementSystem.Model.Report
{
    public class BorrowedReport
    {
        public string MemberName { get; set; }
        public string MemberPhoneNumber { get; set; }
        public string MembershipType { get; set; }
        public List<BorrowedBookDetail> BorrowedBookDetails { get; set; }
        
    }

    public class BorrowedBookDetail
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookIsbn { get; set; }
        //public DateTime IssuedDate { get; set; }
        //public DateTime DueDate { get; set; }
        //public int DueDays { get; set; }
        //public double DueFine { get; set; }
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