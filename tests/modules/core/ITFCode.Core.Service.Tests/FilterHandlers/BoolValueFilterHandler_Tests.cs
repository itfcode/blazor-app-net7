using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class BoolValueFilterHandler_Tests : BaseValueFilterHandler_Tests<bool>
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new BoolValueFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetBoolTestValues))]
        public void Handle_Should_Be_Equal(bool propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<BoolValueFilter>(propValue, propName);
            var expression = new BoolValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        public static IEnumerable<object[]> GetBoolTestValues()
        {
            yield return new object[] { true, "BoolProp", 2 };
            yield return new object[] { false, "BoolProp", 1 };

            yield return new object[] { true, "BoolNullableProp", 2 };
            yield return new object[] { false, "BoolNullableProp", 1 };
        }
    }
}