namespace SanLibrary.Core.Books.ValueObjects
{
    public sealed record ReleaseDate
    {
        public DateTimeOffset Value { get; }

        public ReleaseDate(DateTimeOffset value)
        {
            Value = value.Date.Date;
        }

        public static implicit operator DateTimeOffset(ReleaseDate date)
            => date.Value;

        public static implicit operator ReleaseDate(DateTimeOffset value)
            => new(value);

        public static bool operator <(ReleaseDate date1, ReleaseDate date2)
            => date1.Value < date2.Value;

        public static bool operator >(ReleaseDate date1, ReleaseDate date2)
            => date1.Value > date2.Value;

        public static bool operator <=(ReleaseDate date1, ReleaseDate date2)
            => date1.Value <= date2.Value;

        public static bool operator >=(ReleaseDate date1, ReleaseDate date2)
            => date1.Value >= date2.Value;

        public static ReleaseDate Now => new(DateTimeOffset.Now);

        public override string ToString() => Value.ToString("d");
    }
}