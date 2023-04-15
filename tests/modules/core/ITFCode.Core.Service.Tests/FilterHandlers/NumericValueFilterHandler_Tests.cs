using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class NumericValueFilterHandler_Tests : BaseValueFilterHandler_Tests<double>
    {
        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new NumericValueFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetNumericTestValues))]
        public void Handle_Should_Be_Equal(double propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propValue, propName);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);

            if (propName.Contains("Nullable"))
                Assert.Equal(propValue, res.First().NumericProp);
            else
                Assert.Equal(propValue, res.First().NumericNullableProp);
        }

        public static IEnumerable<object[]> GetNumericTestValues()
        {
            yield return new object[] { TestData.Numeric1, "NumericProp", 1 };
            yield return new object[] { TestData.Numeric2, "NumericProp", 1 };
            yield return new object[] { TestData.Numeric3, "NumericProp", 1 };

            yield return new object[] { TestData.Numeric1, "NumericNullableProp", 1 };
            yield return new object[] { TestData.Numeric2, "NumericNullableProp", 1 };
            yield return new object[] { TestData.Numeric3, "NumericNullableProp", 1 };
        }
    }
}