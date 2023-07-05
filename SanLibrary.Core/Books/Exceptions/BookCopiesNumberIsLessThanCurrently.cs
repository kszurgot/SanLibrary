using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    internal class BookCopiesNumberIsLessThanCurrently : CustomException
    {
        public CopiesNumber NewCopiesNumber { get; }
        public CopiesNumber OldCopiesNumber { get; }
        public BookCopiesNumberIsLessThanCurrently(CopiesNumber newCopiesNumber, CopiesNumber oldCopiesNumber)
            : base($"Book copies number: '{newCopiesNumber.Value}' cannot be less than currently: '{oldCopiesNumber.Value}'.")
        {
            NewCopiesNumber = newCopiesNumber;
            OldCopiesNumber = oldCopiesNumber;
        }
    }
}
