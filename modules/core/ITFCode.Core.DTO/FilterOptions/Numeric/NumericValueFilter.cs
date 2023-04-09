using ITFCode.Core.DTO.FilterOptions.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions
{
    public class NumericValueFilter : FilterValueOption<double>
    {
        [JsonPropertyName("matchMode")]
        [JsonProperty("matchMode")]
        public NumericFilterMatchMode MatchMode { get; set; } = NumericFilterMatchMode.Equals;
    }
}