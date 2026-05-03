using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repository.BookRepository;
using LibraryManagementSystem.Repository.BorrowRepository;
using LibraryManagementSystem.Repository.MemberRepository;

namespace LibraryManagementSystem.Services.BorrowService
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public BorrowService(IBorrowRepository borrowRepository, IBookRepository bookRepository, IMemberRepository memberRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }

        public bool BorrowBook(int bookId, int memberId)
        {
            //***member id should be valid
            //***book id should be valid
            //***book count should be greater than 0
            //**membership validity should be valid
            //**same member id cannont take same book

            var memberList = _memberRepository.ViewAllMembers();
            var memberDetails = memberList.FirstOrDefault(m => m.MemberId == memberId);
            if (memberDetails.ExpirationDate < DateTime.Now)
            {
                //The member with this id has an expired membership, so they cannot borrow books
                return false;
            }
            var bookList = _bookRepository.ViewAllBooks();
            bool doesMemberExist = memberList.Any(m => m.MemberId == memberId);
            bool doesBookExist = bookList.Any(m => m.BookId == bookId);
            if(doesBookExist && doesMemberExist)
            {
                var borrowList = _borrowRepository.ViewAllBorrowLists();
                var hasMemberTakenSameBook = borrowList.Any(x => x.BookId == bookId & x.MemberId == memberId);
                if(hasMemberTakenSameBook)
                {
                    //the member with this id has already taken the same book, so they cannot borrow the same book again
                    return false;
                }
                var bookDetails = bookList.FirstOrDefault(b => b.BookId == bookId);
                var availableCopies = bookDetails?.AvailableCopies;
                if(availableCopies > 0)
                {
                    var bookToEdit = new Book
                    {
                        BookId = bookId,
                        AvailableCopies = (int)(availableCopies - 1),
                        ModifiedBy = "admin",
                        ModifiedDate = DateTime.Now
                    };
                    var isBookUpdated = _bookRepository.UpdateBookCount(bookToEdit);
                    if (isBookUpdated)
                    {
                        _borrowRepository.BorrowBook(bookId, memberId);
                        return true;
                    }
                    else
                    {
                        //if the book count is not updated successfully, then the borrow process cannot be completed
                        return false;
                    }
                }
                else
                {
                    //the book with this id is not available, so the member cannot borrow this book
                    return false;
                }
            }
            else
            {
                //either the book does not exist or the member does not exist, so the borrow process cannot be completed
                return false;
            }
        }

        public double BorrowFine(int bookId, int memberId)
        {
            var borrowList = _borrowRepository.ViewAllBorrowLists();
            var bookDetails = borrowList.FirstOrDefault(x => x.BookId == bookId & x.MemberId == memberId);
            if (bookDetails == null)
            {
                return 0;
            }
            else
            {
                int noOfDaysLate = (DateTime.Now - bookDetails.DueDate).Days;
                if (noOfDaysLate > 0)
                {
                    return _borrowRepository.BorrowFine(bookId, memberId, noOfDaysLate);
                }
                return 0;
            }

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
