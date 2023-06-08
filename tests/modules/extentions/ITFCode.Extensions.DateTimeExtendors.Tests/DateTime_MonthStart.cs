using Shouldly;

namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public partial class DateTime_Reset
    {
        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStartAt_Test(DateTime sourceDate)
        {
            for (var i = 0; i < 10; i++)
            {
                var at = new Random().Next(-10, 10);
                var targetDate = sourceDate.MonthStartAt(at);

                Assert.NotEqual(sourceDate.AddMonths(at), targetDate);
                Assert.Equal(sourceDate.AddMonths(at).Year, targetDate.Year);
                Assert.Equal(sourceDate.AddMonths(at).Month, targetDate.Month);
                Assert.Equal(1, targetDate.Day);
            }
        }

        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStart_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthStart();

            Assert.NotEqual(sourceDate, targetDate);
            Assert.Equal(sourceDate.Year, targetDate.Year);
            Assert.Equal(sourceDate.Month, targetDate.Month);
            Assert.Equal(1, targetDate.Day);
        }

        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStartPrev_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthStartPrev();

            Assert.NotEqual(sourceDate.AddMonths(-1), targetDate);
            Assert.Equal(sourceDate.AddMonths(-1).Year, targetDate.Year);
            Assert.Equal(sourceDate.AddMonths(-1).Month, targetDate.Month);
            Assert.Equal(1, targetDate.Day);
        }

        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEndAt_Test(DateTime sourceDate)
        {
            for (var i = 0; i < 10; i++)
            {
                var at = new Random().Next(-10, 10);
                var targetDate = sourceDate.MonthEndAt(at);

                var modifiedDate = sourceDate.AddMonths(at);

                Assert.Equal(modifiedDate.Year, targetDate.Year);
                Assert.Equal(modifiedDate.Month, targetDate.Month);

                Assert.Equal(1, targetDate.AddDays(1).Day);
                Assert.Equal(23, targetDate.Hour);
                Assert.Equal(59, targetDate.Minute);
                Assert.Equal(59, targetDate.Second);
            }
        }

        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEnd_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthEnd();

            var modifiedDate = sourceDate.AddMonths(0);

            Assert.Equal(modifiedDate.Year, targetDate.Year);
            Assert.Equal(modifiedDate.Month, targetDate.Month);

            Assert.Equal(1, targetDate.AddDays(1).Day);
            Assert.Equal(23, targetDate.Hour);
            Assert.Equal(59, targetDate.Minute);
            Assert.Equal(59, targetDate.Second);
        }

        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEndPrev_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthEndPrev();
            var modifiedDate = sourceDate.AddMonths(-1);

            targetDate.Year.ShouldBe(modifiedDate.Year);
            targetDate.Month.ShouldBe(modifiedDate.Month);

            targetDate.AddDays(1).Day.ShouldBe(1);

            targetDate.Hour.ShouldBe(23);
            targetDate.Minute.ShouldBe(59);
            targetDate.Second.ShouldBe(59);
        }

        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEndNext_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthEndNext();

            var modifiedDate = sourceDate.AddMonths(1);

            Assert.Equal(modifiedDate.Year, targetDate.Year);
            Assert.Equal(modifiedDate.Month, targetDate.Month);

            Assert.Equal(1, targetDate.AddDays(1).Day);
            Assert.Equal(23, targetDate.Hour);
            Assert.Equal(59, targetDate.Minute);
            Assert.Equal(59, targetDate.Second);
        }

        [Theory]
        [MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStartNext_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthStartNext();

            Assert.NotEqual(sourceDate.AddMonths(1), targetDate);
            Assert.Equal(sourceDate.AddMonths(1).Year, targetDate.Year);
            Assert.Equal(sourceDate.AddMonths(1).Month, targetDate.Month);
            Assert.Equal(1, targetDate.Day);
        }

        public static IEnumerable<object[]> TestDataForMonthStartEnd()
        {
            var now = DateTime.Now;
            //var start = new DateTime(now.Year, now.Month, 1);

            var data = new List<object[]>();

            for (int i = 0; i < 10; i++)
            {
                data.Add(new object[]
                {
                    now.AddMonths(new Random().Next(-100, 100))
                });
            }

            return data;
        }
    }
}