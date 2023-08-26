namespace ITFCode.Extensions.StringExtendors
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string self)
            => self switch
            {
                null => throw new ArgumentNullException(nameof(self)),
                "" => throw new ArgumentException($"{nameof(self)} cannot be empty", nameof(self)),
                _ => string.Concat(self[0].ToString().ToUpper(), self.AsSpan(1))
            };
    }
}