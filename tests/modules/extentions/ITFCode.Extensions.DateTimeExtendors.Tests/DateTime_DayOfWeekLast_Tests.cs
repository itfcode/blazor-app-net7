namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public class DateTime_DayOfWeekLast_Tests
    {
        #region Tests

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void MondayLast_Test(DateTime date)
        {
            var monday = date.MondayLast();
            Assert.Equal(DayOfWeek.Monday, monday.DayOfWeek);
            Assert.True(monday.Day >= 22);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void TuesdayLast_Test(DateTime date)
        {
            var tuesday = date.TuesdayLast();
            Assert.Equal(DayOfWeek.Tuesday, tuesday.DayOfWeek);
            Assert.True(tuesday.Day >= 22);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void WednesdayLast_Test(DateTime date)
        {
            var wednesday = date.WednesdayLast();
            Assert.Equal(DayOfWeek.Wednesday, wednesday.DayOfWeek);
            Assert.True(wednesday.Day >= 22);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void ThursdayLast_Test(DateTime date)
        {
            var thursday = date.ThursdayLast();
            Assert.Equal(DayOfWeek.Thursday, thursday.DayOfWeek);
            Assert.True(thursday.Day >= 22);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void FridayLast_Test(DateTime date)
        {
            var friday = date.FridayLast();
            Assert.Equal(DayOfWeek.Friday, friday.DayOfWeek);
            Assert.True(friday.Day >= 22);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void SaturdayLast_Test(DateTime date)
        {
            var saturday = date.SaturdayLast();
            Assert.Equal(DayOfWeek.Saturday, saturday.DayOfWeek);
            Assert.True(saturday.Day >= 22);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekLast))]
        public void SundayLast_Test(DateTime date)
        {
            var sunday = date.SundayLast();
            Assert.Equal(DayOfWeek.Sunday, sunday.DayOfWeek);
            Assert.True(sunday.Day >= 22);
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
    }
}