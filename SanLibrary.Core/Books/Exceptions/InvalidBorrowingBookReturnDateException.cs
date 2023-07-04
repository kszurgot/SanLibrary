using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidBorrowingBookReturnDateException : CustomException
    {
        public ReturnDate ReturnDate { get; }

        public InvalidBorrowingBookReturnDateException(ReturnDate returnDate)
            : base($"Borrowing book return date: '{returnDate}' is invalid.")
        {
            ReturnDate = returnDate;
        }
    }
}
