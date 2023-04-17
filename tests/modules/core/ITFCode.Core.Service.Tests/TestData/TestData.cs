using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ITFCode.Core.Service.Tests
{
    public static class TestData
    {
        #region Private Fileds 

        private static readonly double[] _numeric = new double[] { 1.0, 2.0, 3.0 };

        #endregion

        private static IList<Guid> _guids = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

        private static IList<SimpeItem> _simpeItems = new List<SimpeItem>
        {
            new SimpeItem
            {
                BoolProp = true,
                BoolNullableProp = true,
                DateProp =  DateTime.Now.Date.AddDays(-1),
                DateNullableProp = DateTime.Now.Date.AddDays(-1),
                GuidProp = Guid1,
                GuidNullableProp = Guid1,
                NumericProp = 1,
                NumericNullableProp = 1,
                StringProp = "not-emtpy",
            },
            new SimpeItem
            {
                BoolProp = false,
                BoolNullableProp = false,
                DateProp = DateTime.Now.Date.AddDays(0),
                DateNullableProp = DateTime.Now.Date.AddDays(0),
                GuidProp = Guid2,
                GuidNullableProp = Guid2,
                NumericProp = 2,
                NumericNullableProp = 2,
                StringProp = "empty",
            },
            new SimpeItem
            {
                BoolProp = true,
                BoolNullableProp = true,
                DateProp = DateTime.Now.Date.AddDays(1),
                DateNullableProp = DateTime.Now.Date.AddDays(1),
                GuidProp = Guid3,
                GuidNullableProp = Guid3,
                NumericProp = 3,
                NumericNullableProp = 3,
                StringProp = "not-empty",
            },
        };

        public static IList<Guid> Guids => _guids;

        public static IList<string> Strings => new List<string> { "string1", "string2", "string3" };

        public static IQueryable<SimpeItem> Items = (new List<SimpeItem>
        {
            new SimpeItem
            {
                BoolProp = Bool1,
                BoolNullableProp = Bool1,
                DateProp = DateTime1,
                DateNullableProp = DateTime1,
                GuidProp = Guid1,
                GuidNullableProp = Guid1,
                NumericProp = Numeric1,
                NumericNullableProp = Numeric1,
                StringProp = String1,
                ByteProp = Byte1,
                ByteNullableProp = Byte1,
                ShortProp = Short1,
                ShortNullableProp = Short1,
                DecimalProp = Decimal1,
                DecimalNullableProp = Decimal1,
                DoubleProp = Double1,
                DoubleNullableProp = Double1,
                FloatProp= Float1,
                FloatNullableProp = Float1,
                IntProp= Int1,
                IntNullableProp = Int1,
                LongProp = Long1,
                LongNullableProp = Long1,
            },
            new SimpeItem
            {
                BoolProp = Bool2,
                BoolNullableProp = Bool2,
                DateProp = DateTime2,
                DateNullableProp = DateTime2,
                GuidProp = Guid2,
                GuidNullableProp = Guid2,
                NumericProp = Numeric2,
                NumericNullableProp = Numeric2,
                StringProp = String2,
                ByteProp = Byte2,
                ByteNullableProp = Byte2,
                ShortProp = Short2,
                ShortNullableProp = Short2,
                DecimalProp = Decimal2,
                DecimalNullableProp = Decimal2,
                DoubleProp = Double2,
                DoubleNullableProp = Double2,
                FloatProp= Float2,
                FloatNullableProp = Float2,
                IntProp= Int2,
                IntNullableProp = Int2,
                LongProp = Long2,
                LongNullableProp = Long2,
            },
            new SimpeItem
            {
                BoolProp = Bool3,
                BoolNullableProp = Bool3,
                DateProp = DateTime3,
                DateNullableProp = DateTime3,
                GuidProp = Guid3,
                GuidNullableProp = Guid3,
                NumericProp = Numeric3,
                NumericNullableProp = Numeric3,
                StringProp = String3,
                ByteProp = Byte3,
                ByteNullableProp = Byte3,
                ShortProp = Short3,
                ShortNullableProp = Short3,
                DecimalProp = Decimal3,
                DecimalNullableProp = Decimal3,
                DoubleProp = Double3,
                DoubleNullableProp = Double3,
                FloatProp= Float3,
                FloatNullableProp = Float3,
                IntProp= Int3,
                IntNullableProp = Int3,
                LongProp = Long3,
                LongNullableProp = Long3,
            },
        }).AsQueryable();

        #region Public Properties 

        public static bool Bool1 => true;
        public static bool Bool2 => false;
        public static bool Bool3 => true;

        public static int Numeric1 => 1;
        public static int Numeric2 => 2;
        public static int Numeric3 => 3;

        public static byte Byte1 => (byte)_numeric[0];
        public static byte Byte2 => (byte)_numeric[1];
        public static byte Byte3 => (byte)_numeric[2];

        public static short Short1 => (short)_numeric[0];
        public static short Short2 => (short)_numeric[1];
        public static short Short3 => (short)_numeric[2];

        public static int Int1 => (int)_numeric[0];
        public static int Int2 => (int)_numeric[1];
        public static int Int3 => (int)_numeric[2];

        public static long Long1 => (long)_numeric[0];
        public static long Long2 => (long)_numeric[1];
        public static long Long3 => (long)_numeric[2];

        public static float Float1 => (float)_numeric[0];
        public static float Float2 => (float)_numeric[1];
        public static float Float3 => (float)_numeric[2];

        public static double Double1 => _numeric[0];
        public static double Double2 => _numeric[1];
        public static double Double3 => _numeric[2];

        public static decimal Decimal1 => (decimal)_numeric[0];
        public static decimal Decimal2 => (decimal)_numeric[1];
        public static decimal Decimal3 => (decimal)_numeric[2];

        public static Guid Guid1 => Guids[0];
        public static Guid Guid2 => Guids[1];
        public static Guid Guid3 => Guids[2];

        public static string String1 => Strings[0];
        public static string String2 => Strings[1];
        public static string String3 => Strings[2];

        public static DateTime DateTime1 => DateTime.Now.Date.AddDays(-2);
        public static DateTime DateTime2 => DateTime.Now.Date;
        public static DateTime DateTime3 => DateTime.Now.Date.AddDays(2);

        #endregion
    }
}