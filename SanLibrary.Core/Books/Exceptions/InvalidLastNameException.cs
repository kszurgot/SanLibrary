using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidLastNameException : CustomException
    {
        public string? LastName { get; }

        public InvalidLastNameException(string? lastName) : base($"Last name: '{lastName}' is invalid.")
        {
            LastName = lastName;
        }
    }
}
