using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Actors.Runtime;
using Microsoft.AspNetCore.Mvc;
using Order.API.Actors;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IActorProxyFactory _actorProxyFactory;
        public OrderController(IActorProxyFactory actorProxyFactory)
        {
            _actorProxyFactory = actorProxyFactory;
        }

        [HttpPut]
        public async Task<Guid> SubmitOrder([FromBody] OrderRequest orderRequest)
        {
            var actorId = new ActorId(Guid.NewGuid().ToString());
            var proxy = _actorProxyFactory.CreateActorProxy<IOrderActor>(actorId, nameof(OrderActor));
            return await proxy.SubmitAsync(orderRequest.Buyer, orderRequest.OrderItems.ToList());
        }

        [HttpGet]
        public async Task<Actors.Order> GetOrderStatus(Guid orderId)
        {
            var actorId = new ActorId(orderId.ToString());
            var proxy = _actorProxyFactory.CreateActorProxy<IOrderActor>(actorId, nameof(OrderActor));
            return await proxy.GetDetails();
        }
    }
}
