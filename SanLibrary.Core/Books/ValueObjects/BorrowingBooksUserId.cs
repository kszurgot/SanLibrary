using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public record BorrowingBooksUserId
    {
        public Guid Value { get; }

        public BorrowingBooksUserId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static BorrowingBooksUserId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(BorrowingBooksUserId date)
            => date.Value;

        public static implicit operator BorrowingBooksUserId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}
