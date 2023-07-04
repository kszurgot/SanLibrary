using SanLibrary.Core.Publishers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Publishers.ValueObjects
{
    public sealed record Name
    {
        public string Value { get; }

        public Name(string? value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidNameException(value);
            }

            Value = value;
        }

        public static implicit operator Name(string value) => new(value);

        public static implicit operator string(Name value) => value.Value;

        public override string ToString() => Value;
    }
}
