using System.Text.RegularExpressions;

namespace ITFCode.MudBlazorInfo.Static
{
    public static class RegexHelper
    {
        public static string SimplifyTypes(string input) 
        {
            var output = input.Trim() ?? string.Empty;

            foreach (var item in AppData.TypeAliasesInRegex)
            {
                output = Regex.Replace(output, item.Key, item.Value);
                output = Regex.Replace(output, item.Key, item.Value);
                output = Regex.Replace(output, item.Key, item.Value);
            }

            foreach (var pattern in AppData.TypePatternsInRegex)
            {
                output = Regex.Replace(output, pattern.Key, pattern.Value);
                output = Regex.Replace(output, pattern.Key, pattern.Value);
                output = Regex.Replace(output, pattern.Key, pattern.Value);
            }

            return output;
        }
    }
}