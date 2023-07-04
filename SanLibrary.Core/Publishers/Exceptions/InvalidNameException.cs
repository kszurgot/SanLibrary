using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Publishers.Exceptions
{
    public sealed class InvalidNameException : CustomException
    {
        public string? Name { get; }

        public InvalidNameException(string? name) : base($"Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
