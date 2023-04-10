using ITFCode.Core.DTO.FilterOptions.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions
{
    public class StringValueFilter : FilterValueOption<string>
    {
        [JsonPropertyName("matchMode")]
        [JsonProperty("matchMode")]
        public StringFilterMatchMode MatchMode { get; set; } = StringFilterMatchMode.Contains;
    }
}
