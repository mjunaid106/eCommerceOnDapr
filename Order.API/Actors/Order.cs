namespace Order.API.Actors
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;
        public Buyer Buyer { get; internal set; }
        public IEnumerable<OrderItem> OrderItems { get; internal set; }
        public Guid Id { get; internal set; }
    }
}