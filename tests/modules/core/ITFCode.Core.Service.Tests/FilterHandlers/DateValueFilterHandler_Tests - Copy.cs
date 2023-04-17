using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;
using System.Linq;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateValueFilterHandler_Tests1 : BaseValueFilterHandler_Tests<DateTime>
    {

        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new DateValueFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetDateTestValues))]
        public void Handle_Should_Be_Equal(string propName, DateTime propValue, DateFilterMatchMode matchMode, int itemCount)
        {
            var filter = CreateFilter<DateValueFilter>(propName, propValue);
            filter.MatchMode = matchMode;   

            var expression = new DateValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        public static IEnumerable<object[]> GetDateTestValues()
        {
            yield return new object[] { "DateProp", TestData.DateTime1, DateFilterMatchMode.Equals, 1 };
            yield return new object[] { "DateProp", TestData.DateTime1, DateFilterMatchMode.LessThan, 0 };
            yield return new object[] { "DateProp", TestData.DateTime1, DateFilterMatchMode.LessThanOrEquals, 1 };
            yield return new object[] { "DateProp", TestData.DateTime1, DateFilterMatchMode.GreaterThan, 2 };
            yield return new object[] { "DateProp", TestData.DateTime1, DateFilterMatchMode.GreaterThanOrEquals, 3 };

            yield return new object[] { "DateProp", TestData.DateTime2, DateFilterMatchMode.Equals, 1 };
            yield return new object[] { "DateProp", TestData.DateTime2, DateFilterMatchMode.LessThan, 1 };
            yield return new object[] { "DateProp", TestData.DateTime2, DateFilterMatchMode.LessThanOrEquals, 2 };
            yield return new object[] { "DateProp", TestData.DateTime2, DateFilterMatchMode.GreaterThan, 1 };
            yield return new object[] { "DateProp", TestData.DateTime2, DateFilterMatchMode.GreaterThanOrEquals, 2 };

            yield return new object[] { "DateProp", TestData.DateTime3, DateFilterMatchMode.Equals, 1 };
            yield return new object[] { "DateProp", TestData.DateTime3, DateFilterMatchMode.LessThan, 2 };
            yield return new object[] { "DateProp", TestData.DateTime3, DateFilterMatchMode.LessThanOrEquals, 3 };
            yield return new object[] { "DateProp", TestData.DateTime3, DateFilterMatchMode.GreaterThan, 0 };
            yield return new object[] { "DateProp", TestData.DateTime3, DateFilterMatchMode.GreaterThanOrEquals, 1 };
        }
    }
}