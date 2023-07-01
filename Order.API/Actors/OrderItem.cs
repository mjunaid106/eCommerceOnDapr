namespace Order.API.Actors
{
    public record OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}