using Dapr.Actors;

namespace Order.API.Actors
{
    public interface IOrderActor : IActor
    {
        Task<Guid> SubmitAsync(Buyer buyer, IList<OrderItem> products);
        Task<Order> GetDetails();
    }
}
