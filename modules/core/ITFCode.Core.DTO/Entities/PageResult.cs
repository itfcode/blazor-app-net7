using Newtonsoft.Json;

namespace ITFCode.Core.DTO.Entities
{
    public class PageResult<TEnityDTO> where TEnityDTO : class
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public IEnumerable<TEnityDTO> Items { get; set; } = Enumerable.Empty<TEnityDTO>();
    }
}
