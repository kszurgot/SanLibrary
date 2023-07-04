using SanLibrary.Core.Books.Exceptions;

namespace SanLibrary.Core.Books.ValueObjects
{
    public record CopiesNumber
    {
        public int Value { get; }

        public CopiesNumber(int value)
        {
            if (value is < 1)
            {
                throw new InvalidCopiesNumberException(value);
            }

            Value = value;
        }

        public static implicit operator int(CopiesNumber capacity)
            => capacity.Value;

        public static implicit operator CopiesNumber(int capacity)
            => new(capacity);
    }
}