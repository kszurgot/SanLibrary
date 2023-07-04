using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidBorrowingBookDateException : CustomException
    {
        public Date Date { get; }

        public InvalidBorrowingBookDateException(Date date)
            : base($"Borrowing book date: '{date}' is invalid.")
        {
            Date = date;
        }
    }
}
