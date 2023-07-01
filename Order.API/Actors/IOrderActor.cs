using Dapr.Actors;

namespace Order.API.Actors
{
    public interface IOrderActor : IActor
    {
        Task<Guid> SubmitAsync(Buyer buyer, OrderItem products);
        Task<Order> GetDetails();
    }
}
