namespace ITFCode.Extensions.StringExtendors.Tests
{
    public class StringExtentions_Tests
    {
        #region Method 'FirstCharToUpper' Tests

        [Fact]
        public void FirstCharToUpper_Throw_If_Value_Is_Null()
        {
            string? value = null;
            Assert.Throws<ArgumentNullException>(() => value.FirstCharToUpper());
        }

        [Fact]
        public void FirstCharToUpper_Throw_If_Value_Is_Empty()
        {
            string? value = string.Empty;
            Assert.Throws<ArgumentException>(() => value.FirstCharToUpper());
        }

        [Fact]
        public void FirstCharToUpper_Success_If_Param()
        {
            Assert.Equal("Silk", "silk".FirstCharToUpper());
            Assert.Equal("Silk", "Silk".FirstCharToUpper());
            Assert.Equal("SILK", "sILK".FirstCharToUpper());
            Assert.Equal("2silk", "2silk".FirstCharToUpper());
            Assert.Equal("K", "k".FirstCharToUpper());
        }

        #endregion
    }
}