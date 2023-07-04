using SanLibrary.Core.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public sealed record LastName
    {
        public string Value { get; }

        public LastName(string? value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 20 or < 2)
            {
                throw new InvalidLastNameException(value);
            }

            Value = value;
        }

        public static implicit operator LastName(string value) => new(value);

        public static implicit operator string(LastName value) => value.Value;

        public override string ToString() => Value;
    }
}
