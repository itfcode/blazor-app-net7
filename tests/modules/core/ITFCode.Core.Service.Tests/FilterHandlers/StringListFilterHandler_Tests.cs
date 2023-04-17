using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;
using static ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class StringListFilterHandler_Tests : BaseListFilterHandler_Tests<string>
    {

        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new StringListFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetStringTestLists))]
        public void Handle_Should_Be_Equal(string propName, IEnumerable<string> propValues, int itemCount)
        {
            var filter = CreateFilter<StringListFilter>(propValues.Select(x => x).ToList(), propName);
            var expression = new StringListFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        public static IEnumerable<object[]> GetStringTestLists()
        {
            yield return new object[] { "StringProp", new string[] { }, 0 };
            yield return new object[] { "StringProp", new string[] { String1 }, 1 };
            yield return new object[] { "StringProp", new string[] { String1, String2 }, 2 };
            yield return new object[] { "StringProp", new string[] { String1, String2, String3 }, 3 };
        }
    }
}