using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions.Base
{
    public abstract class FilterValueOption<T> : FilterOption
    {
        [JsonPropertyName("value")]
        [JsonProperty("value")]
        public T Value { get; set; }
    }
}