using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public record BorrowingBookId
    {
        public Guid Value { get; }

        public BorrowingBookId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static BorrowingBookId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(BorrowingBookId date)
            => date.Value;

        public static implicit operator BorrowingBookId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}
