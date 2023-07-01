namespace Order.API.Actors
{
    public record Buyer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}