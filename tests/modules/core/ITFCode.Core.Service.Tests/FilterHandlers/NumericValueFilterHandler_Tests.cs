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
        [MemberData(nameof(GetByteTestValues))]
        public void Handle_Should_Be_Equal(byte propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propName, propValue);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);

            //if (propName.Contains("Nullable"))
            //    Assert.Equal(propValue, res.First().NumericProp);
            //else
            //    Assert.Equal(propValue, res.First().NumericNullableProp);
        }

        [Theory]
        [MemberData(nameof(GetShortTestValues))]
        public void Handle_Should_Be_Equal_Short_Type(short propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propName, propValue);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        [Theory]
        [MemberData(nameof(GetIntTestValues))]
        public void Handle_Should_Be_Equal_Int_Type(int propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propName, propValue);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        [Theory]
        [MemberData(nameof(GetLongTestValues))]
        public void Handle_Should_Be_Equal_Long_Type(long propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propName, propValue);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        [Theory]
        [MemberData(nameof(GetDoubleTestValues))]
        public void Handle_Should_Be_Equal_Double_Type(double propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propName, propValue);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        [Theory]
        [MemberData(nameof(GetFloatTestValues))]
        public void Handle_Should_Be_Equal_Float_Type(float propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propName, propValue);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        [Theory]
        [MemberData(nameof(GetDecimalTestValues))]
        public void Handle_Should_Be_Equal_Decimal_Type(decimal propValue, string propName, int itemCount)
        {
            var filter = CreateFilter<NumericValueFilter>(propName, (double)propValue);
            var expression = new NumericValueFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
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

        public static IEnumerable<object[]> GetByteTestValues()
        {
            yield return new object[] { TestData.Byte1, "ByteProp", 1 };
            yield return new object[] { TestData.Byte2, "ByteProp", 1 };
            yield return new object[] { TestData.Byte3, "ByteProp", 1 };

            yield return new object[] { TestData.Byte1, "ByteNullableProp", 1 };
            yield return new object[] { TestData.Byte2, "ByteNullableProp", 1 };
            yield return new object[] { TestData.Byte3, "ByteNullableProp", 1 };
        }

        public static IEnumerable<object[]> GetShortTestValues()
        {
            yield return new object[] { TestData.Short1, "ShortProp", 1 };
            yield return new object[] { TestData.Short2, "ShortProp", 1 };
            yield return new object[] { TestData.Short3, "ShortProp", 1 };

            yield return new object[] { TestData.Short1, "ShortNullableProp", 1 };
            yield return new object[] { TestData.Short2, "ShortNullableProp", 1 };
            yield return new object[] { TestData.Short3, "ShortNullableProp", 1 };
        }

        public static IEnumerable<object[]> GetIntTestValues()
        {
            yield return new object[] { TestData.Int1, "IntProp", 1 };
            yield return new object[] { TestData.Int2, "IntProp", 1 };
            yield return new object[] { TestData.Int3, "IntProp", 1 };

            yield return new object[] { TestData.Int1, "IntNullableProp", 1 };
            yield return new object[] { TestData.Int2, "IntNullableProp", 1 };
            yield return new object[] { TestData.Int3, "IntNullableProp", 1 };
        }

        public static IEnumerable<object[]> GetLongTestValues()
        {
            yield return new object[] { TestData.Long1, "LongProp", 1 };
            yield return new object[] { TestData.Long2, "LongProp", 1 };
            yield return new object[] { TestData.Long3, "LongProp", 1 };

            yield return new object[] { TestData.Long1, "LongNullableProp", 1 };
            yield return new object[] { TestData.Long2, "LongNullableProp", 1 };
            yield return new object[] { TestData.Long3, "LongNullableProp", 1 };
        }

        public static IEnumerable<object[]> GetDoubleTestValues()
        {
            yield return new object[] { TestData.Double1, "DoubleProp", 1 };
            yield return new object[] { TestData.Double2, "DoubleProp", 1 };
            yield return new object[] { TestData.Double3, "DoubleProp", 1 };

            yield return new object[] { TestData.Double1, "DoubleNullableProp", 1 };
            yield return new object[] { TestData.Double2, "DoubleNullableProp", 1 };
            yield return new object[] { TestData.Double3, "DoubleNullableProp", 1 };
        }

        public static IEnumerable<object[]> GetDecimalTestValues()
        {
            yield return new object[] { TestData.Decimal1, "DecimalProp", 1 };
            yield return new object[] { TestData.Decimal2, "DecimalProp", 1 };
            yield return new object[] { TestData.Decimal3, "DecimalProp", 1 };

            yield return new object[] { TestData.Decimal1, "DecimalNullableProp", 1 };
            yield return new object[] { TestData.Decimal2, "DecimalNullableProp", 1 };
            yield return new object[] { TestData.Decimal3, "DecimalNullableProp", 1 };
        }

        public static IEnumerable<object[]> GetFloatTestValues()
        {
            yield return new object[] { TestData.Float1, "FloatProp", 1 };
            yield return new object[] { TestData.Float2, "FloatProp", 1 };
            yield return new object[] { TestData.Float3, "FloatProp", 1 };

            yield return new object[] { TestData.Float1, "FloatNullableProp", 1 };
            yield return new object[] { TestData.Float2, "FloatNullableProp", 1 };
            yield return new object[] { TestData.Float3, "FloatNullableProp", 1 };
        }
    }
}