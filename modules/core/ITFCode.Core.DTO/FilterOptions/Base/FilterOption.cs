using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions.Base
{
    public abstract class FilterOption
    {
        [JsonPropertyName("propertyName")]
        [JsonProperty("propertyName")]
        public string PropertyName { get; set; }

        [JsonPropertyName("typeFilter")]
        [JsonProperty("typeFilter")]
        public string TypeFilter => GetType().Name;
    }
}