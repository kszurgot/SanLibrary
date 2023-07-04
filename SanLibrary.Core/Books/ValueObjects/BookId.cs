using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public record BookId
    {
        public Guid Value { get; }

        public BookId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static BookId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(BookId date)
            => date.Value;

        public static implicit operator BookId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}
