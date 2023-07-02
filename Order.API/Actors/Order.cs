using System.Text.Json.Serialization;

namespace Order.API.Actors
{
    public record Order
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("orderStatus")]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;

        [JsonPropertyName("buyer")]
        public Buyer Buyer { get; set; }

        [JsonPropertyName("orderItesm")]
        public OrderItem OrderItem { get; set; }
    }
}