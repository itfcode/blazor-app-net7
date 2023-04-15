using ITFCode.Core.Service.Data.FilterHandlers;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class NumericListFilterHandler_Tests
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new NumericListFilterHandler(null));
        }
    }
}