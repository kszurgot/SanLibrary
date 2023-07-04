using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    internal class BookAlreadyBorrowedAllCopiesException : CustomException
    {
        public BookId BookId { get; }
        public BookAlreadyBorrowedAllCopiesException(BookId bookId)
            : base($"Cannot borrowing book with ID: '{bookId}'. All copies are borrowed.")
        {
            BookId = bookId;
        }
    }
}
