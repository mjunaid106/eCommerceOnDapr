namespace Order.API.Actors
{
    public record Product
    {
        public Guid Id { get; set; }
        public int QuantityAvailable { get; set; }
    }
}