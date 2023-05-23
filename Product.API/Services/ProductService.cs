using Dapr.Client;
namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private const string DAPR_STORE_NAME = "statestore";
        DaprClient client;

        public ProductService()
        {
            client = new DaprClientBuilder().Build();
        }

        public async Task<Guid> CreateProductAsync(Models.Product product)
        {
            product.Id = Guid.NewGuid();
            await client.SaveStateAsync(DAPR_STORE_NAME, product.Id.ToString(), product);
            return product.Id;
        }

        public async Task<Models.Product> GetProductAsync(Guid productId)
        {
            return await client.GetStateAsync<Models.Product>(DAPR_STORE_NAME, productId.ToString());
        }
    }
}
