using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateValueFilterHandler_Tests : BaseValueFilterHandler_Tests<DateTime>
    {

        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new DateValueFilterHandler(null));
        }


        [Theory]
        [MemberData(nameof(GetDateTestValues))]
        public void Handle_Should_Be_Equal(DateTime propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<DateValueFilter>(propValue, propName);
            var expression = new DateValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
            Assert.Equal(propValue, res.First().DateProp);
        }

        public static IEnumerable<object[]> GetDateTestValues()
        {
            yield return new object[] { TestData.DateTime1, "DateProp", 1 };
            yield return new object[] { TestData.DateTime2, "DateProp", 1 };
            yield return new object[] { TestData.DateTime3, "DateProp", 1 };

            yield return new object[] { TestData.DateTime1, "DateNullableProp", 1 };
            yield return new object[] { TestData.DateTime2, "DateNullableProp", 1 };
            yield return new object[] { TestData.DateTime3, "DateNullableProp", 1 };
        }
    }
}