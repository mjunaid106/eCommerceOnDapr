using Dapr.Actors.Runtime;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.Metrics;

namespace Order.API.Actors
{
    public class OrderActor : Actor, IOrderActor
    {
        private const string OrderDetailsStateName = "OrderDetails";
        //private const string OrderStatusStateName = "OrderStatus";

        private Guid OrderId => Guid.Parse(Id.GetId());
        DaprClient client;

        public OrderActor(ActorHost host) : base(host)
        {
            client = new DaprClientBuilder().Build();
        }

        protected override Task OnActivateAsync()
        {
            Console.WriteLine($"Activating actor id: {this.Id}");
            return Task.CompletedTask;
        }

        public Task<Order> GetDetails()
        {
            return StateManager.GetStateAsync<Order>(OrderDetailsStateName);
        }

        public async Task<Guid> SubmitAsync(Buyer buyer, IEnumerable<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = OrderId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.Submitted,
                Buyer = buyer,
                OrderItems = orderItems,
            };

            var request = client.CreateInvokeMethodRequest(HttpMethod.Get, "product-api", $"/api/Product/{orderItems.First().Product.Id}");
            var product = client.InvokeMethodAsync<Product>(request);

            await StateManager.SetStateAsync(OrderDetailsStateName, order);
            return OrderId;
        }
    }
}
