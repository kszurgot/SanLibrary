using SanLibrary.Core.Books.Entities;
using SanLibrary.Core.Books.Exceptions;
using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.DomainServices
{
    internal sealed class BorrowingBookDomainService : IBorrowingBookDomainService
    {
        private readonly IClock _clock;

        public BorrowingBookDomainService(IClock clock)
        {
            _clock = clock;
        }

        public void Borrow(
            IEnumerable<BorrowingBook> allBorrowedBooks,
            BorrowingBooksUser currentBorrowingBooksUser,
            BorrowingBook borrowingBook,
            CopiesNumber copiesNumber)
        {
            var borrowingBooksInInterval = allBorrowedBooks.Count(b => b.BookId == borrowingBook.BookId
                && (
                    b.Date.Value >= borrowingBook.Date.Value && b.Date.Value <= borrowingBook.ReturnDate.Value
                    || b.ReturnDate.Value >= borrowingBook.Date.Value && b.ReturnDate.Value <= borrowingBook.ReturnDate.Value
                ));

            if (borrowingBooksInInterval >= copiesNumber)
            {
                throw new BookAlreadyBorrowedAllCopiesException(borrowingBook.BookId);
            }

            currentBorrowingBooksUser.AddBook(borrowingBook, _clock);
        }
    }
}
