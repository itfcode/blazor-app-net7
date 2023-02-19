namespace ITFCode.MudBlazorInfo.Static
{
    public static class AppData 
    {
        public static readonly IDictionary<string, string> TypePatternsInRegex = new Dictionary<string, string>
        {
            {@"System\.Nullable`1\[(\w+)\]", "$1?" },
            {@"IEnumerable`1\[(\w+)\]", "IEnumerable<$1>" },
            {@"ICollection`1\[(\w+)\]", "ICollection<$1>" },
            {@"IList`1\[(\w+)\]", "IList<$1>" },
        };

        public static readonly IDictionary<string, string> TypeAliasesInRegex = new Dictionary<string, string>
        {
            //{ @"\bBoolean\b", "boolean" },

            //{ @"\bByte\b", "byte" },
            //{ @"\bInt32\b", "int" },
            //{ @"\bInt64\b", "long" },
            //{ @"\bDecimal\b", "decimal" },
            //{ @"\bSingle\b", "float" },
            //{ @"\bString\b", "string" },

            { @"\bSystem\.DateTime\b", "DateTime" },
            { @"\bSystem\.DateTimeOffset\b", "DateTimeOffset" },

            { @"\bSystem\.Byte\b", "byte" },
            { @"\bSystem\.Int32\b", "int" },
            { @"\bSystem\.Int64\b", "long" },
            { @"\bSystem\.Decimal\b", "decimal" },
            { @"\bSystem\.Single\b", "float" },
            { @"\bSystem\.String\b", "string" },

            { @"\bSystem\.Collections\.Generic\.ICollection", "ICollection" },
            { @"\bSystem\.Collections\.Generic\.IEnumerable", "IEnumerable" },
            { @"\bSystem\.Collections\.Generic\.IList", "IList" },
        };
    }
}
