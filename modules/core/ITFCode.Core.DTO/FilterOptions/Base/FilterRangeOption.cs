using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions.Base
{
    public abstract class FilterRangeOption<T> : FilterOption
    {
        [JsonPropertyName("from")]
        [JsonProperty("from")]
        public T From { get; set; }

        [JsonPropertyName("to")]
        [JsonProperty("to")]
        public T To { get; set; }
    }
}