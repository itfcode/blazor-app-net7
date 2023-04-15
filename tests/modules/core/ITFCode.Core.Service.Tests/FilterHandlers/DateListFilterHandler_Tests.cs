using ITFCode.Core.Service.Data.FilterHandlers;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateListFilterHandler_Tests
    {

        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new DateListFilterHandler(null));
        }
    }
}