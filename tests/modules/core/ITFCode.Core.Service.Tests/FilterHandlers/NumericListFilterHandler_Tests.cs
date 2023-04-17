using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;
using static ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class NumericListFilterHandler_Tests : BaseListFilterHandler_Tests<int>
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new NumericListFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetListTestLists))]
        public void Handle_Should_Be_Equal(string propName, IEnumerable<int> propValues, int itemCount)
        {
            var filter = CreateFilter<NumericListFilter>(propValues, propName);
            var expression = new NumericListFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
            //Assert.Equal(propValue, res.First().DateProp);
        }

        public static IEnumerable<object[]> GetListTestLists()
        {
            yield return new object[] { "NumericProp", new int[] { }, 0 };
            yield return new object[] { "NumericProp", new int[] { }, 1 };
            yield return new object[] { "NumericProp", new int[] { }, 2 };
            yield return new object[] { "NumericProp", new int[] { }, 3 };

            yield return new object[] { "NumericNullableProp", new int[] { }, 0 };
            yield return new object[] { "NumericNullableProp", new int[] { }, 1 };
            yield return new object[] { "NumericNullableProp", new int[] { }, 2 };
            yield return new object[] { "NumericNullableProp", new int[] { }, 3 };
        }
    }
}