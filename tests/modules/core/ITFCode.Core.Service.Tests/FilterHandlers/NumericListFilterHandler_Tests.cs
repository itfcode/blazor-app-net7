using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;
using System.Linq;
using static ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class NumericListFilterHandler_Tests : BaseListFilterHandler_Tests<double>
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
            var filter = CreateFilter<NumericListFilter>(propValues.Select(x => (double)x).ToList(), propName);
            var expression = new NumericListFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
            //Assert.Equal(propValue, res.First().DateProp);
        }

        [Theory]
        [MemberData(nameof(GetByteTestLists))]
        public void Handle_Should_Be_Equal_Byte_Type(string propName, IEnumerable<byte> propValues, int itemCount)
        {
            var filter = CreateFilter<NumericListFilter>(propValues.Select(c => (double)c).ToList(), propName);
            var expression = new NumericListFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        public static IEnumerable<object[]> GetListTestLists()
        {
            yield return new object[] { "NumericProp", new int[] { }, 0 };
            yield return new object[] { "NumericProp", new int[] { Numeric1 }, 1 };
            yield return new object[] { "NumericProp", new int[] { Numeric1, Numeric2 }, 2 };
            yield return new object[] { "NumericProp", new int[] { Numeric1, Numeric2, Numeric3 }, 3 };

            yield return new object[] { "NumericNullableProp", new int[] { }, 0 };
            yield return new object[] { "NumericNullableProp", new int[] { Numeric1 }, 1 };
            yield return new object[] { "NumericNullableProp", new int[] { Numeric1, Numeric2 }, 2 };
            yield return new object[] { "NumericNullableProp", new int[] { Numeric1, Numeric2, Numeric3 }, 3 };
        }

        public static IEnumerable<object[]> GetByteTestLists()
        {
            yield return new object[] { "ByteProp", new byte[] { }, 0 };
            yield return new object[] { "ByteProp", new byte[] { Byte1 }, 1 };
            yield return new object[] { "ByteProp", new byte[] { Byte1, Byte2 }, 2 };
            yield return new object[] { "ByteProp", new byte[] { Byte1, Byte2, Byte3 }, 3 };

            yield return new object[] { "ByteNullableProp", new byte[] { }, 0 };
            yield return new object[] { "ByteNullableProp", new byte[] { Byte1 }, 1 };
            yield return new object[] { "ByteNullableProp", new byte[] { Byte1, Byte2 }, 2 };
            yield return new object[] { "ByteNullableProp", new byte[] { Byte1, Byte2, Byte3 }, 3 };
        }

        public static IEnumerable<object[]> GetShortTestLists()
        {
            yield return new object[] { "ShortProp", new short[] { }, 0 };
            yield return new object[] { "ShortProp", new short[] { Short1 }, 1 };
            yield return new object[] { "ShortProp", new short[] { Short1, Short2 }, 2 };
            yield return new object[] { "ShortProp", new short[] { Short1, Short2, Short3 }, 3 };

            yield return new object[] { "ShortNullableProp", new short[] { }, 0 };
            yield return new object[] { "ShortNullableProp", new short[] { Short1 }, 1 };
            yield return new object[] { "ShortNullableProp", new short[] { Short1, Short2 }, 2 };
            yield return new object[] { "ShortNullableProp", new short[] { Short1, Short2, Short3 }, 3 };
        }
    }
}