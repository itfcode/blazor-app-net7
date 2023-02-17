using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection;
using System.Text.RegularExpressions;
//using static MudBlazor.CategoryTypes;

namespace ITFCode.MudBlazorInfo.Pages
{
    public partial class LibraryInfo : ComponentBase
    {
        private Assembly _assembly;
        private Dictionary<string, Assembly> _extentions = new Dictionary<string, Assembly>();
        private IList<string> _namespaceNames = new List<string>();

        private IList<ExpansionPanelSetting> _expansionPanels = new List<ExpansionPanelSetting>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Init();
        }

        private void Init()
        {
            _assembly = Assembly.GetExecutingAssembly();

            _namespaceNames = new List<string>
            {
                "ITFCode.Extensions.BooleanExtendors",
                "ITFCode.Extensions.ComparableExtendors",
                "ITFCode.Extensions.DateTimeExtendors",
                "ITFCode.Extensions.DateTimeNullableExtendors",
                "ITFCode.Extensions.DateTimeOffsetExtendors",
                "ITFCode.Extensions.DateTimeOffsetNullableExtendors",
                "ITFCode.Extensions.DictionaryExtendors",
                "ITFCode.Extensions.EnumerableExtendors",
                "ITFCode.Extensions.JavaScriptEnxtendors",
                "ITFCode.Extensions.ListExtendors",
                "ITFCode.Extensions.NumberExtendors",
                "ITFCode.Extensions.ObjectExtendors",
                "ITFCode.Extensions.QueryableExtendors",
                "ITFCode.Extensions.StringExtendors",
                "ITFCode.Extensions.TypeExtendors"
            };

            foreach (var namespaceName in _namespaceNames)
            {
                _expansionPanels.Add(new ExpansionPanelSetting { Name = namespaceName });

                var classesInNamespace = Assembly.Load(namespaceName)
                    .GetTypes()
                    .Where(t => string.Equals(t.Namespace, namespaceName, StringComparison.Ordinal))
                    .Where(t => t.IsAbstract && t.IsSealed)
                    .ToList();

                foreach (var @class in classesInNamespace)
                {
                    Console.WriteLine($"Name:{@class.Name}, IsAutoClass: {@class.IsAutoClass} ");

                    var methods = @class.GetMethods(BindingFlags.Public | BindingFlags.Static).ToArray();

                    foreach (var method in methods)
                    {
                        Console.WriteLine($"  { method.Name }, { Clear(method.ToString()) }");
                    }
                }
            }
        }

        private string Clear(string input)
        {
            var output = input;

            // 
            foreach (var item in TypeAliases.All)
            {
                output = Regex.Replace(output, item.Key, item.Value);
            }

            // for Nullable
            
            var patterns = new Dictionary<string, string> 
            {
                {@"System\.Nullable`1\[(\w+)\]", "$1?" },
                {@"IEnumerable`1\[(\w+)\]", "IEnumerable<$1>" },
            };

            foreach (var pattern in patterns) 
            {
                output = Regex.Replace(output, pattern.Key, pattern.Value);
                output = Regex.Replace(output, pattern.Key, pattern.Value);
            }


            return output;
        }
    }

    public class ExpansionPanelSetting
    {
        public bool IsExpanded { get; set; }
        public string Name { get; set; }

        public ExpansionPanelSetting() { }
    }


    public static class TypeAliases
    {
        public static IDictionary<string, string> All = new Dictionary<string, string>
        {
            { @"\bSystem\.Single\b", "float" },
            { @"\bSystem\.String\b", "string" },
            { @"\bSystem\.Decimal\b", "decimal" },
            { @"\bSystem\.Byte\b", "byte" },

            { @"\bSystem\.DateTime\b", "DateTime" },
            { @"\bSystem\.DateTimeOffset\b", "DateTimeOffset" },

            { @"\bSystem\.Nullable`1[System\.DateTime]\b", "DateTime?" },
            { @"\bSystem\.Nullable`1[System\.DateTimeOffset]\b", "DateTimeOffset?" },

            { @"\bSystem\.Collections\.Generic\.IEnumerable", "IEnumerable" },
            { @"\bSystem\.Collections\.Generic\.ICollection", "ICollection" },
            { @"\bSystem\.Collections\.Generic\.IList", "IList" },
        };
    }
}