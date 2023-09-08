using ITFCode.Extensions.DateTimeOffsetExtendors.Tests.Base;

namespace ITFCode.Extensions.DateTimeOffsetExtendors.Tests
{
    public class DateTimeOffsetExtensions_Tests : DateTimeOffset_Base_Tests
    {
        #region Tests 

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void MondayFirst_Test(DateTimeOffset date)
        {
            CheckValues(date.MondayFirst(),date, DayOfWeek.Monday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void TuesdayFirst_Test(DateTimeOffset date)
        {
            CheckValues(date.TuesdayFirst(), date, DayOfWeek.Tuesday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void WednesdayFirst_Test(DateTimeOffset date)
        {
            CheckValues(date.WednesdayFirst(), date, DayOfWeek.Wednesday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void ThursdayFirst_Test(DateTimeOffset date)
        {
            CheckValues(date.ThursdayFirst(), date, DayOfWeek.Thursday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void FridayFirst_Test(DateTimeOffset date)
        {
            CheckValues(date.FridayFirst(), date, DayOfWeek.Friday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void SaturdayFirst_Test(DateTimeOffset date)
        {
            CheckValues(date.SaturdayFirst(), date, DayOfWeek.Saturday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void SundayFirst_Test(DateTimeOffset date)
        {
            CheckValues(date.SundayFirst(), date, DayOfWeek.Sunday);
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestDataFor_DayOfWeekFirst()
        {
            var now = DateTime.Now;

            var data = new List<object[]>();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    var offset = new Random().Next(-14, 14);
                    var hours = new Random().Next(0, 23);
                    var minutes = new Random().Next(0, 59);
                    var seconds = new Random().Next(0, 59);
                    var milliseconds = new Random().Next(0, 999);
                    var microseconds = new Random().Next(0, 999);
                    var dateTime = new DateTime(2010 + i, 1 + j, 1, hours, minutes, seconds, milliseconds, microseconds, DateTimeKind.Unspecified);
                    var date = new DateTimeOffset(dateTime, new TimeSpan(offset, 0, 0)).AddDays(new Random().Next(0, 28));
                    data.Add(new object[] { date });
                }
            }

            return data;
        }

        #endregion

        #region Private Methods 

        private void CheckValues(DateTimeOffset target, DateTimeOffset source, DayOfWeek dayOfWeek)
        {
            Assert.Equal(dayOfWeek, target.DayOfWeek);
            Assert.Equal(0, target.Hour);
            Assert.Equal(0, target.Minute);
            Assert.Equal(0, target.Second);
            Assert.Equal(0, target.Microsecond);
            Assert.Equal(0, target.Microsecond);
            Assert.Equal(0, target.Nanosecond);
            Assert.Equal(source.Offset, target.Offset);
            Assert.True(target.Day <= 7);
        }

        #endregion

    }
}