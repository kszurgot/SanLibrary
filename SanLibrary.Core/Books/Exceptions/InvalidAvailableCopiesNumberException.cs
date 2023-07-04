using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidAvailableCopiesNumberException : CustomException
    {
        public int AvailableCopiesNumber { get; }

        public InvalidAvailableCopiesNumberException(int availableCopiesNumber) 
            : base($"Number of copies available: '{availableCopiesNumber}' is invalid.")
        {
            AvailableCopiesNumber = availableCopiesNumber;
        }
    }
}
