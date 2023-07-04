using SanLibrary.Core.Books.Exceptions;

namespace SanLibrary.Core.Books.ValueObjects
{
    public record AvailableCopiesNumber
    {
        public int Value { get; }

        public AvailableCopiesNumber(int value)
        {
            if (value is < 0)
            {
                throw new InvalidAvailableCopiesNumberException(value);
            }

            Value = value;
        }

        public static implicit operator int(AvailableCopiesNumber capacity)
            => capacity.Value;

        public static implicit operator AvailableCopiesNumber(int capacity)
            => new(capacity);
    }
}