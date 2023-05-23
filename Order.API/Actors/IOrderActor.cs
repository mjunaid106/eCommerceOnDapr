using Dapr.Actors;

namespace Order.API.Actors
{
    public interface IOrderActor : IActor
    {
        Task<Guid> SubmitAsync(Buyer buyer, IEnumerable<OrderItem> products);
        Task<Order> GetDetails();
    }
}
