namespace ITFCode.Core.Extensions.ComparableExtendors.Tests
{
    using AutoFixture;

    public class ComparableExtensions_WithinAny_Tests
    {
        #region Private Fields

        private static readonly int _valueCount = 200;
        private static readonly Fixture _fixture = new();

        #endregion

        #region Tests

        [Theory]
        [MemberData(nameof(GetDecimals))]
        public void WithinAny_For_Decimal_Test(decimal value)
        {
            Assert.True(value.WithinAny((decimal.MinValue, 0), (0, decimal.MaxValue)));
            Assert.True(value.WithinAny((value, value), (value - 1, value + 1), (0, 0), (value + 1, decimal.MaxValue)));

            Assert.False(value.WithinAny((decimal.MinValue, value - 1), (value + 1, decimal.MaxValue)));
            Assert.False(value.WithinAny((value + 1, decimal.MaxValue), (decimal.MinValue, value - 1)));
        }

        [Theory]
        [MemberData(nameof(GetIntregers))]
        public void Within_For_Integer_Test(int value)
        {
            Assert.True(value.WithinAll((int.MinValue, int.MaxValue)));
            Assert.True(value.Within(value, value));
            Assert.True(value.Within(int.MinValue, value));
            Assert.True(value.Within(value, int.MaxValue));

            Assert.False(value.Within(int.MinValue, value - 1));
            Assert.False(value.Within(value + 1, int.MaxValue));
        }

        [Theory]
        [MemberData(nameof(GetDates))]
        public void Within_For_DateTime_Test(DateTime value)
        {
            Assert.True(value.Within(DateTime.MinValue, DateTime.MaxValue));
            Assert.True(value.Within(value, value.AddTicks(1)));
            Assert.True(value.Within(value.AddTicks(-1), value));
            Assert.True(value.Within(value.AddTicks(-1), value.AddTicks(1)));

            Assert.False(value.Within(value.AddTicks(-2), value.AddTicks(-1)));
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> GetDecimals()
        {
            for (int i = 0; i < _valueCount; i++)
            {
                var value = _fixture.Create<decimal>() * new Random().Next(-5, 5);
                yield return new object[] { value } ;
            }
        }

        public static IEnumerable<object[]> GetFloats()
        {
            for (int i = 0; i < _valueCount; i++)
                yield return new object[] { _fixture.Create<float>() * new Random().Next(-5, 5) };
        }

        public static IEnumerable<object[]> GetDoubles()
        {
            for (int i = 0; i < _valueCount; i++)
                yield return new object[] { _fixture.Create<double>() * new Random().Next(-5, 5) };
        }

        public static IEnumerable<object[]> GetIntregers()
        {
            for (int i = 0; i < _valueCount; i++)
                yield return new object[] { _fixture.Create<int>() * new Random().Next(-5, 5) };
        }

        public static IEnumerable<object[]> GetDates()
        {
            for (int i = 0; i < _valueCount; i++)
                yield return new object[] { _fixture.Create<DateTime>() };
        }

        #endregion
    }
}