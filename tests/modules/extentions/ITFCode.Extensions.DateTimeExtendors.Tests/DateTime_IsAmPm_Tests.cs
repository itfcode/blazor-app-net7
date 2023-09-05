namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public class DateTime_IsAmPm_Tests
    {
        #region Tests

        [Theory]
        [MemberData(nameof(TestDataFor_IsAm))]
        public void IsAM_Test(DateTime date)
        {
            Assert.True(date.IsAM());
        }

        [Theory]
        [MemberData(nameof(TestDataFor_IsPm))]
        public void IsPM_Test(DateTime date)
        {
            Assert.True(date.IsPM());
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestDataFor_IsAm()
        {
            var now = DateTime.Now;

            var data = new List<object[]>();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    var hh = new Random().Next(0, 11);
                    var mm = new Random().Next(1, 59);
                    var ss = new Random().Next(1, 59);
                    var date = new DateTime(2010 + i, 1 + j, 1, hh, mm, ss).AddDays(new Random().Next(0, 28));
                    data.Add(new object[]
                    {
                        date
                    });
                }
            }

            return data;
        }

        public static IEnumerable<object[]> TestDataFor_IsPm()
        {
            var now = DateTime.Now;

            var data = new List<object[]>();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    var hh = new Random().Next(12, 23);
                    var mm = new Random().Next(1, 59);
                    var ss = new Random().Next(1, 59);
                    var date = new DateTime(2010 + i, 1 + j, 1, hh, mm, ss).AddDays(new Random().Next(0, 28));
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