using ITFCode.Core.DTO.FilterOptions.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions
{
    public class DateValueFilter : FilterValueOption<DateTime>
    {
        [JsonPropertyName("matchMode")]
        [JsonProperty("matchMode")]
        public DateFilterMatchMode MatchMode { get; set; } = DateFilterMatchMode.Equals;
    }
}