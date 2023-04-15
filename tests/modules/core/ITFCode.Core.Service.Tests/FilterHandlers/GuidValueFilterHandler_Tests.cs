using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class GuidValueFilterHandler_Tests : BaseValueFilterHandler_Tests<Guid>
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new GuidValueFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetGuidTestValues))]
        public void Handle_Should_Be_Equal(Guid propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<GuidValueFilter>(propValue, propName);
            var expression = new GuidValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
            Assert.Equal(propValue, res.First().GuidProp);
        }

        public static IEnumerable<object[]> GetGuidTestValues()
        {
            yield return new object[] { TestData.Guid1, "GuidProp", 1 };
            yield return new object[] { TestData.Guid2, "GuidProp", 1 };
            yield return new object[] { TestData.Guid3, "GuidProp", 1 };

            yield return new object[] { TestData.Guid1, "GuidNullableProp", 1 };
            yield return new object[] { TestData.Guid2, "GuidNullableProp", 1 };
            yield return new object[] { TestData.Guid3, "GuidNullableProp", 1 };
        }
    }
}