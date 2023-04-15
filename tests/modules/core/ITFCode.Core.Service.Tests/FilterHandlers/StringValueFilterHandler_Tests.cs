using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class StringValueFilterHandler_Tests : BaseValueFilterHandler_Tests<string>
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new StringValueFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetGuidTestValues))]
        public void Handle_Should_Be_Equal(string propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<StringValueFilter>(propValue, propName);
            var expression = new StringValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
            Assert.Equal(propValue, res.First().StringProp);
        }

        public static IEnumerable<object[]> GetGuidTestValues()
        {
            yield return new object[] { TestData.String1, "StringProp", 1 };
            yield return new object[] { TestData.String2, "StringProp", 1 };
            yield return new object[] { TestData.String3, "StringProp", 1 };
        }
    }
}