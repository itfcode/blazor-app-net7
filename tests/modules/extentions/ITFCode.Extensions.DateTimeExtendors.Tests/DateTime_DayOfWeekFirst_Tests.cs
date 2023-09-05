namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public class DateTime_DayOfWeekFirst_Tests
    {
        #region Tests 

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void MondayFirst_Test(DateTime date)
        {
            var monday = date.MondayFirst();
            Assert.Equal(DayOfWeek.Monday, monday.DayOfWeek);
            Assert.True(monday.Day <= 7);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void TuesdayFirst_Test(DateTime date)
        {
            var tuesday = date.TuesdayFirst();
            Assert.Equal(DayOfWeek.Tuesday, tuesday.DayOfWeek);
            Assert.True(tuesday.Day <= 7);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void WednesdayFirst_Test(DateTime date)
        {
            var wednesday = date.WednesdayFirst();
            Assert.Equal(DayOfWeek.Wednesday, wednesday.DayOfWeek);
            Assert.True(wednesday.Day <= 7);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void ThursdayFirst_Test(DateTime date)
        {
            var thursday = date.ThursdayFirst();
            Assert.Equal(DayOfWeek.Thursday, thursday.DayOfWeek);
            Assert.True(thursday.Day <= 7);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void FridayFirst_Test(DateTime date)
        {
            var friday = date.FridayFirst();
            Assert.Equal(DayOfWeek.Friday, friday.DayOfWeek);
            Assert.True(friday.Day <= 7);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void SaturdayFirst_Test(DateTime date)
        {
            var saturday = date.SaturdayFirst();
            Assert.Equal(DayOfWeek.Saturday, saturday.DayOfWeek);
            Assert.True(saturday.Day <= 7);
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayOfWeekFirst))]
        public void SundayFirst_Test(DateTime date)
        {
            var sunday = date.SundayFirst();
            Assert.Equal(DayOfWeek.Sunday, sunday.DayOfWeek);
            Assert.True(sunday.Day <= 7);
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