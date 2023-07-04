using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Entities
{
    public class BorrowingBook
    {
        public BorrowingBookId Id { get; private set; }
        public BookId BookId { get; private set; }
        public Date Date { get; private set; }
        public ReturnDate ReturnDate { get; private set; }



        public BorrowingBook(BorrowingBookId id, BookId bookId, Date date, ReturnDate returnDate)
        {
            Id = id;
            BookId = bookId;
            Date = date;
            ReturnDate = returnDate;
        }
    }
}
