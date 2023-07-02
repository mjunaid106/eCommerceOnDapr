using Dapr.Actors;
using Order.API.Models;

namespace Order.API.Actors
{
    public interface IOrderActor : IActor
    {
        Task<Guid> SubmitAsync(Buyer buyer, OrderItem products);
        Task<Models.Order> GetDetails();
    }
}
