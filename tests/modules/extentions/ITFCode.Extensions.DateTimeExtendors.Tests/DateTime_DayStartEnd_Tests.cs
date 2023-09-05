namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public class DateTime_DayStartEnd_Tests
    {
        #region Tests 

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStartAt_Test(DateTime date)
        {
            var days = new Random().Next(-365, 365);
            Assert.Equal(date.AddDays(days).Date, date.DayStartAt(days));
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStart_Test(DateTime date)
        {
            Assert.Equal(date.Date, date.DayStart());
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStartPrev_Test(DateTime date)
        {
            Assert.Equal(date.AddDays(-1).Date, date.DayStartPrev());
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayStartNext_Test(DateTime date)
        {
            Assert.Equal(date.AddDays(1).Date, date.DayStartNext());
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayEndAt_Test(DateTime date)
        {
            var days = new Random().Next(-365, 365);
            Assert.Equal(date.AddDays(days).Date, date.DayStartAt(days));
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayEnd_Test(DateTime date)
        {
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayEndPrev_Test(DateTime date)
        {
        }

        [Theory]
        [MemberData(nameof(TestDataFor_DayStartEnd))]
        public void DayEndNext_Test(DateTime date)
        {
        }

        #endregion

        #region Tests Data 

        public static IEnumerable<object[]> TestDataFor_DayStartEnd()
        {
            var data = new List<object[]>();

            for (int i = 0; i < 100; i++)
            {
                var date = DateTime.Now.AddDays(new Random().Next(-365, 365));
                data.Add(new object[]
                {
                    date
                });
            }

            return data;
        }

        #endregion
    }
}