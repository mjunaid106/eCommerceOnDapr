using System.Text.Json.Serialization;

namespace Order.API.Actors
{
    public record Buyer
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}