using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public partial class DateTime_Reset
    {
        [Fact]
        public void ResetMilliseconds_Test1()
        {
            //
        }

        [Fact]
        public void ResetSeconds_Test1()
        {
            //
        }

        [Fact]
        public void ResetMinutes_Test1()
        {
            //
        }

        [Fact]
        public void ResetHours_Test1()
        {
            //
        }

        public static IEnumerable<object[]> TestDataForReset()
        {
            var data = new List<object[]>();

            for (int i = 0; i < 10; i++)
            {
                data.Add(new object[]
                {
                    DateTime.Now
                        .AddDays(new Random().Next(-100,100))
                        .AddHours(new Random().Next(-100,100))
                        .AddMinutes(new Random().Next(-100,100))
                        .AddSeconds(new Random().Next(-100,100))
                        .AddMilliseconds(new Random().Next(-100,100))
                });
            }

            return data;
        }
    }
}