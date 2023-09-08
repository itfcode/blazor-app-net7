using ITFCode.Extensions.DateTimeOffsetExtendors.Tests.Base;

namespace ITFCode.Extensions.DateTimeOffsetExtendors.Tests
{
    public class DateTimeOffset_DayStartEnd_Tests : DateTimeOffset_Base_Tests
    {
        #region Day Start

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStartAt_Test(DateTimeOffset date)
        {
            var days = new Random().Next(-365, 365);
            CheckValues(expected: date.AddDays(days), actual: date.DayStartAt(days));
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStart_Test(DateTimeOffset date)
        {
            CheckValues(expected: date, actual: date.DayStart());
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStartPrev_Test(DateTimeOffset date)
        {
            CheckValues(expected: date.AddDays(-1), actual: date.DayStartPrev());
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStartNext_Test(DateTimeOffset date)
        {
            CheckValues(expected: date.AddDays(1), actual: date.DayStartNext());
        }

        #endregion

        #region Day End

        #endregion

        #region Test Data

        public static IEnumerable<object[]> TestDataFor_DayStartEnd()
            => GenerateTestData();

        #endregion

        #region Private Methods 

        private void CheckValues(DateTimeOffset expected, DateTimeOffset actual)
        {
            Assert.Equal(expected.Year, actual.Year);
            Assert.Equal(expected.Month, actual.Month);
            Assert.Equal(expected.Day, actual.Day);

            Assert.Equal(0, actual.Hour);
            Assert.Equal(0, actual.Minute);
            Assert.Equal(0, actual.Second);
            Assert.Equal(0, actual.Microsecond);
            Assert.Equal(0, actual.Microsecond);
            Assert.Equal(0, actual.Nanosecond);

            Assert.Equal(expected.Offset, actual.Offset);
        }

        #endregion
    }
}
