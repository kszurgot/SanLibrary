using SanLibrary.Core.Books.Exceptions;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public record Month
    {
        public int Value { get; }

        public Month(int value)
        {
            if (value is < 1 or > 12)
            {
                throw new InvalidMonthException(value);
            }

            Value = value;
        }

        public static implicit operator int(Month month)
            => month.Value;

        public static implicit operator Month(int month)
            => new(month);
    }
}
