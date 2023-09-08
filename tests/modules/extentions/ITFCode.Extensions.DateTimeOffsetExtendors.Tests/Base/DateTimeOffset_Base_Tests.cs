namespace ITFCode.Extensions.DateTimeOffsetExtendors.Tests.Base
{
    public abstract class DateTimeOffset_Base_Tests
    {
        public static IEnumerable<object[]> GenerateTestData()
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
    }
}
