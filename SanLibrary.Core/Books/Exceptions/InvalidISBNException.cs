using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidISBNException : CustomException
    {
        public string? ISBN { get; }

        public InvalidISBNException(string? ISBN) : base($"ISBN: '{ISBN}' is invalid.")
        {
            this.ISBN = ISBN;
        }
    }
}
