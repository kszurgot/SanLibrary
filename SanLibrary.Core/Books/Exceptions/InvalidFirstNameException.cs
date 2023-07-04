using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidFirstNameException : CustomException
    {
        public string? FirstName { get; }

        public InvalidFirstNameException(string? firstName) : base($"First name: '{firstName}' is invalid.")
        {
            FirstName = firstName;
        }
    }
}
