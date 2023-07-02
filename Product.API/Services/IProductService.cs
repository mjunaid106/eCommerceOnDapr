namespace Product.API.Services
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(Models.Product product);
        Task<Models.Product> GetProductAsync(Guid productId);
        Task<Models.Product> UpdateAvailableAmount(Guid id, int quantity);
    }
}