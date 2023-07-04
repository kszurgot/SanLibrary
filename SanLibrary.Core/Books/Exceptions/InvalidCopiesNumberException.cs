using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidCopiesNumberException : CustomException
    {
        public int CopiesNumber { get; }

        public InvalidCopiesNumberException(int copiesNumber) 
            : base($"Number of copies: '{copiesNumber}' is invalid.")
        {
            CopiesNumber = copiesNumber;
        }
    }
}
