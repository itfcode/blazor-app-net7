using Newtonsoft.Json;

namespace ITFCode.Core.DTO.Entities
{
    public class PageResult<TEnityDTO> where TEnityDTO : class
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public IReadOnlyCollection<TEnityDTO> Items { get; set; } = new List<TEnityDTO>();
    }
}
