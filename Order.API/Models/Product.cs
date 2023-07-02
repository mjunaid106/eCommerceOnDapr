using System.Text.Json.Serialization;

namespace Order.API.Models
{
    public record Product
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("quantityAvailable")]
        public int QuantityAvailable { get; set; }
    }
}