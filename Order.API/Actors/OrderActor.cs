﻿using Dapr.Actors.Runtime;
using Dapr.Client;
using Order.API.Models;

namespace Order.API.Actors
{
    public class OrderActor : Actor, IOrderActor
    {
        private const string OrderDetailsStateName = "OrderDetails";
        private const string STATE_STORE_NAME = "ecommerceondapr-statestore";
        DaprClient client;

        public OrderActor(ActorHost host) : base(host)
        {
            client = new DaprClientBuilder().Build();
        }
        //private const string OrderStatusStateName = "OrderStatus";

        private Guid OrderId => Guid.Parse(Id.GetId());

        public Task<Models.Order> GetDetails()
        {
            return StateManager.GetStateAsync<Models.Order>(OrderDetailsStateName);
        }

        public async Task<Guid> SubmitAsync(Buyer buyer, OrderItem orderItems)
        {
            var order = new Models.Order
            {
                Id = OrderId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.Submitted,
                Buyer = buyer,
                OrderItem = orderItems,
            };
            var httpClient = DaprClient.CreateInvokeHttpClient();
            var product = await httpClient.GetFromJsonAsync<Product>($"http://product-api/api/product?productId={orderItems.Product.Id}");

            if (product?.QuantityAvailable >= orderItems.Quantity)
            {
                await StateManager.SetStateAsync(OrderDetailsStateName, order);
                await client.PublishEventAsync(STATE_STORE_NAME, "neworder", order);
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