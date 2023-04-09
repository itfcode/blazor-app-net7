using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions.Base
{
    public abstract class FilterListOption<T> : FilterOption
    {
        [JsonPropertyName("values")]
        [JsonProperty("values")]
        public List<T> Values { get; set; } = new List<T>();
    }
}