using Order.API.Actors;

namespace Order.API.Controllers
{
    public class OrderRequest
    {
        public Buyer Buyer { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}