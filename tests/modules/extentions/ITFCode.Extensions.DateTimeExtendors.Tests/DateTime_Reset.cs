namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public partial class DateTime_Reset
    {
        [Theory]
        [MemberData(nameof(TestDataForReset))]
        public void ResetMilliseconds_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.ResetMilliseconds();

            Assert.Equal(sourceDate.Year, targetDate.Year);
            Assert.Equal(sourceDate.Month, targetDate.Month);
            Assert.Equal(sourceDate.Day, targetDate.Day);
            Assert.Equal(sourceDate.Hour, targetDate.Hour);
            Assert.Equal(sourceDate.Minute, targetDate.Minute);
            Assert.Equal(sourceDate.Second, targetDate.Second);
            Assert.Equal(0, targetDate.Millisecond);
        }

        [Theory]
        [MemberData(nameof(TestDataForReset))]
        public void ResetSeconds_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.ResetSeconds();

            Assert.Equal(sourceDate.Year, targetDate.Year);
            Assert.Equal(sourceDate.Month, targetDate.Month);
            Assert.Equal(sourceDate.Day, targetDate.Day);
            Assert.Equal(sourceDate.Hour, targetDate.Hour);
            Assert.Equal(sourceDate.Minute, targetDate.Minute);
            Assert.Equal(0, targetDate.Second);
            Assert.Equal(0, targetDate.Millisecond);
        }

        [Theory]
        [MemberData(nameof(TestDataForReset))]
        public void ResetMinutes_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.ResetMinutes();

            Assert.Equal(sourceDate.Year, targetDate.Year);
            Assert.Equal(sourceDate.Month, targetDate.Month);
            Assert.Equal(sourceDate.Day, targetDate.Day);
            Assert.Equal(sourceDate.Hour, targetDate.Hour);
            Assert.Equal(0, targetDate.Minute);
            Assert.Equal(0, targetDate.Second);
            Assert.Equal(0, targetDate.Millisecond);
        }

        [Theory]
        [MemberData(nameof(TestDataForReset))]
        public void ResetHours_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.ResetHours();

            Assert.Equal(sourceDate.Year, targetDate.Year);
            Assert.Equal(sourceDate.Month, targetDate.Month);
            Assert.Equal(sourceDate.Day, targetDate.Day);
            Assert.Equal(0, targetDate.Hour);
            Assert.Equal(0, targetDate.Minute);
            Assert.Equal(0, targetDate.Second);
            Assert.Equal(0, targetDate.Millisecond);
        }
    }
}