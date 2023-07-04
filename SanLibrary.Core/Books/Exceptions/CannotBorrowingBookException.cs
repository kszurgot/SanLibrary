using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class CannotBorrowingBookException : CustomException
    {
        public BookId BookId { get; }

        public CannotBorrowingBookException(BookId bookId)
            : base($"Cannot borrowing book with ID: '{bookId}'.")
        {
            BookId = bookId;
        }
    }
}
