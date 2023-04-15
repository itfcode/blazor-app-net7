using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ITFCode.Core.Service.Tests
{
    public static class TestData
    {
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
            },
        }).AsQueryable();

        #region Public Properties 

        public static bool Bool1 => true;
        public static bool Bool2 => false;
        public static bool Bool3 => true;

        public static int Numeric1 => 1;
        public static int Numeric2 => 2;
        public static int Numeric3 => 3;

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