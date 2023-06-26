namespace Order.API.Actors
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityAvailable { get; set; }
    }
}