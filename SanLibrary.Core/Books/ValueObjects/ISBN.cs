using SanLibrary.Core.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public sealed record ISBN
    {
        public string Value { get; }

        public ISBN(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidISBNException(value);
            }

            value = value.Replace("-", "").Replace(" ", "");
            if (value.Length is not 13)
            {
                throw new InvalidISBNException(value);
            }

            int sum = 0;
            foreach (var (index, digit) in value.Select((digit, index) => (index, digit)))
            {
                if (!char.IsDigit(digit))
                {
                    throw new InvalidISBNException(value);
                }

                sum += (digit - '0') * (index % 2 == 0 ? 1 : 3);
            }

            if (sum % 10 is not 0)
            {
                throw new InvalidISBNException(value);
            }

            Value = value;
        }

        public static implicit operator ISBN(string? value) => new (value);

        public static implicit operator string(ISBN value) => value.Value;

        public override string ToString() => Value;
    }
}
