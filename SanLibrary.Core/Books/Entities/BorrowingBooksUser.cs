using SanLibrary.Core.Books.Exceptions;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Time;
using SanLibrary.Core.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Entities
{
    public class BorrowingBooksUser
    {
        private const int ReturnLimitDays = 14;
        private readonly HashSet<BorrowingBook> _books = new();
        public BorrowingBooksUserId Id { get; private set; }
        public UserId UserId { get; private set; }
        public Month Month { get; private set; }
        public IEnumerable<BorrowingBook> Books => _books;

        public BorrowingBooksUser(BorrowingBooksUserId borrowingBooksId, UserId userId, Month month)
        {
            Id = borrowingBooksId;
            UserId = userId;
            Month = month;
        }

        internal void AddBook(BorrowingBook book, IClock clock)
        {
            if (_books.Count >= 3)
            {
                throw new CannotBorrowingBookException(book.BookId);
            }

            if (book.Date.Value < clock.Current() 
                || book.Date.Value >= book.ReturnDate.Value 
                || book.Date.Value.Month != Month)
            {
                throw new InvalidBorrowingBookDateException(book.Date);
            }

            if (book.ReturnDate.Value > clock.Current().AddDays(ReturnLimitDays))
            {
                throw new InvalidBorrowingBookReturnDateException(book.ReturnDate);
            }

            _books.Add(book);
        }
    }
}
