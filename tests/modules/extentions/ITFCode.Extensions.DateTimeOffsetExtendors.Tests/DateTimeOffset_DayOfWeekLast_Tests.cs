using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITFCode.Extensions.DateTimeOffsetExtendors.Tests.Base;

namespace ITFCode.Extensions.DateTimeOffsetExtendors.Tests
{
    public class DateTimeOffset_DayOfWeekLast_Tests : DateTimeOffset_Base_Tests
    {
        #region Tests

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void MondayLast_Test(DateTimeOffset date)
        {
            CheckValues(date.MondayLast(), date, DayOfWeek.Monday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void TuesdayLast_Test(DateTimeOffset date)
        {
            CheckValues(date.TuesdayLast(), date, DayOfWeek.Tuesday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void WednesdayLast_Test(DateTimeOffset date)
        {
            CheckValues(date.WednesdayLast(), date, DayOfWeek.Wednesday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void ThursdayLast_Test(DateTimeOffset date)
        {
            CheckValues(date.ThursdayLast(), date, DayOfWeek.Thursday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void FridayLast_Test(DateTimeOffset date)
        {
            CheckValues(date.FridayLast(), date, DayOfWeek.Friday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void SaturdayLast_Test(DateTimeOffset date)
        {
            CheckValues(date.SaturdayLast(), date, DayOfWeek.Saturday);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void SundayLast_Test(DateTimeOffset date)
        {
            CheckValues(date.SundayLast(), date, DayOfWeek.Sunday);
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestDataFor_DayOfWeekLast()
        {
            var now = DateTime.Now;

            var data = new List<object[]>();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    var date = new DateTime(2010 + i, 1 + j, 1).AddDays(new Random().Next(0, 28));
                    data.Add(new object[]
                    {
                        date
                    });
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
            Assert.True(target.AddDays(7).Day <= 7);
        }

        #endregion

    }
}
