namespace Order.API.Actors
{
    public record Order
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;
        public Buyer Buyer { get; internal set; }
        public OrderItem OrderItem { get; internal set; }
        public Guid Id { get; internal set; }
    }
}