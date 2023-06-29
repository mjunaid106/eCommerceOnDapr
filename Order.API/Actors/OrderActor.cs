using Dapr.Actors.Runtime;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.Metrics;
using System.Net.Http.Json;

namespace Order.API.Actors
{
    public class OrderActor : Actor, IOrderActor
    {
        private const string OrderDetailsStateName = "OrderDetails";
        DaprClient client;

        public OrderActor(ActorHost host) : base(host)
        {
            client = new DaprClientBuilder().Build();
        }
        //private const string OrderStatusStateName = "OrderStatus";

        private Guid OrderId => Guid.Parse(Id.GetId());

        public Task<Order> GetDetails()
        {
            return StateManager.GetStateAsync<Order>(OrderDetailsStateName);
        }

        public async Task<Guid> SubmitAsync(Buyer buyer, IList<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = OrderId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.Submitted,
                Buyer = buyer,
                OrderItems = orderItems,
            };
            var httpClient = DaprClient.CreateInvokeHttpClient();
            var product = await httpClient.GetFromJsonAsync<Product>($"http://product-api/api/product?productId={orderItems.First().Product.Id}");

            if (product.QuantityAvailable >= orderItems.First().Quantity)
            {
                await StateManager.SetStateAsync(OrderDetailsStateName, order);
                await client.PublishEventAsync<Order>("pubsub", "neworder", order);
                return OrderId;
            }
            return Guid.Empty;
        }

        protected override Task OnActivateAsync()
        {
            Console.WriteLine($"Activating actor id: {this.Id}");
            return Task.CompletedTask;
        }
    }
}