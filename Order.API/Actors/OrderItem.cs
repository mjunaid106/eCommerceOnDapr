using System.Text.Json.Serialization;

namespace Order.API.Actors
{
    public record OrderItem
    {
        [JsonPropertyName("product")]
        public Product Product { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}