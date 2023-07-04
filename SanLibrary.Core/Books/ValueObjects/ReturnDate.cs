namespace SanLibrary.Core.Books.ValueObjects
{
    public sealed record ReturnDate
    {
        public DateTimeOffset Value { get; }

        public ReturnDate(DateTimeOffset value)
        {
            Value = value.Date.Date;
        }

        public static implicit operator DateTimeOffset(ReturnDate date)
            => date.Value;

        public static implicit operator ReturnDate(DateTimeOffset value)
            => new(value);

        public static bool operator <(ReturnDate date1, ReturnDate date2)
            => date1.Value < date2.Value;

        public static bool operator >(ReturnDate date1, ReturnDate date2)
            => date1.Value > date2.Value;

        public static bool operator <=(ReturnDate date1, ReturnDate date2)
            => date1.Value <= date2.Value;

        public static bool operator >=(ReturnDate date1, ReturnDate date2)
            => date1.Value >= date2.Value;

        public static ReturnDate Now => new(DateTimeOffset.Now);

        public override string ToString() => Value.ToString("d");
    }
}