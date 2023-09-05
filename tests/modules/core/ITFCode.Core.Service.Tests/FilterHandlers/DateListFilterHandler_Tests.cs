using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateListFilterHandler_Tests : BaseListFilterHandler_Tests<DateTime>
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new DateListFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetDateTestLists))]
        public void Handle_Should_Be_Equal(IEnumerable<DateTime> propValues, string propName, int itemCount)
        {
            var filter = CreateFilter<DateListFilter>(propValues, propName);
            var expression = new DateListFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
            //Assert.Equal(propValue, res.First().DateProp);
        }

        public static IEnumerable<object[]> GetDateTestLists()
        {
            //yield return new object[] { new DateTime[] { }, "DateProp", 0 };
            yield return new object[] { new DateTime[] { TestData.DateTime1 }, "DateProp", 1 };
            yield return new object[] { new DateTime[] { TestData.DateTime1, TestData.DateTime2 }, "DateProp", 2 };
            yield return new object[] { new DateTime[] { TestData.DateTime1, TestData.DateTime2, TestData.DateTime3 }, "DateProp", 3 };

            //yield return new object[] { new DateTime[] { }, "DateNullableProp", 0 };
            yield return new object[] { new DateTime[] { TestData.DateTime1 }, "DateNullableProp", 1 };
            yield return new object[] { new DateTime[] { TestData.DateTime1, TestData.DateTime2 }, "DateNullableProp", 2 };
            yield return new object[] { new DateTime[] { TestData.DateTime1, TestData.DateTime2, TestData.DateTime3 }, "DateNullableProp", 3 };
        }
    }
}