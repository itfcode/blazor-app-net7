using ITFCode.Core.DTO.FilterOptions.Base;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITFCode.Core.DTO.FilterOptions
{
    public class QueryFilterOptions
    {
        [JsonPropertyName("sortField")]
        [JsonProperty("sortField")]
        public string SortField { get; set; }

        [JsonPropertyName("isAsc")]
        [JsonProperty("isAsc")]
        public bool IsAsc { get; set; } = true;

        [JsonPropertyName("take")]
        [JsonProperty("take")]
        public int Take { get; set; } = 50;

        [JsonPropertyName("skip")]
        [JsonProperty("skip")]
        public int Skip { get; set; } = 0;

        [JsonPropertyName("filters")]
        [JsonProperty("filters")]
        public List<FilterOption> Filters { get; set; } = new List<FilterOption>();
    }
}