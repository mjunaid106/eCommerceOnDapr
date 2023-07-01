using Order.API.Actors;

namespace Order.API.Controllers
{
    public record OrderRequest
    {
        public Buyer Buyer { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}