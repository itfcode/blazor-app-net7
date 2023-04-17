using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;
using static ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateRangeFilterHandler_Tests : BaseRangeFilterHandler_Tests<DateTime>
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new DateRangeFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetDateTestLists))]
        public void Handle_Should_Be_Equal(string propName, DateTime propValueFrom, DateTime propValueTo, int itemCount)
        {
            var filter = CreateFilter<DateRangeFilter>(propName, propValueFrom, propValueTo);
            var expression = new DateRangeFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
            //Assert.Equal(propValue, res.First().DateProp);
        }

        public static IEnumerable<object[]> GetDateTestLists()
        {
            yield return new object[] { "DateProp", DateTime1.AddDays(-1), DateTime1, 1 };
            yield return new object[] { "DateProp", DateTime1, DateTime1, 1 };
            yield return new object[] { "DateProp", DateTime1, DateTime2, 2 };
            yield return new object[] { "DateProp", DateTime1, DateTime3, 3 };
            yield return new object[] { "DateProp", DateTime2, DateTime3, 2 };
            yield return new object[] { "DateProp", DateTime1.AddDays(-1), DateTime3.AddDays(1), 3 };

            yield return new object[] { "DateNullableProp", DateTime1.AddDays(-1), DateTime1, 1 };
            yield return new object[] { "DateNullableProp", DateTime1, DateTime1, 1 };
            yield return new object[] { "DateNullableProp", DateTime1, DateTime2, 2 };
            yield return new object[] { "DateNullableProp", DateTime1, DateTime3, 3 };
            yield return new object[] { "DateNullableProp", DateTime2, DateTime3, 2 };
            yield return new object[] { "DateNullableProp", DateTime1.AddDays(-1), DateTime3.AddDays(1), 3 };
        }
    }
}