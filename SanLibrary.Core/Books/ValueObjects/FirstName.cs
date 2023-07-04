using SanLibrary.Core.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public sealed record FirstName
    {
        public string Value { get; }

        public FirstName(string? value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 20 or < 2)
            {
                throw new InvalidFirstNameException(value);
            }

            Value = value;
        }

        public static implicit operator FirstName(string? value) => new(value);

        public static implicit operator string(FirstName value) => value.Value;

        public override string ToString() => Value;
    }
}
