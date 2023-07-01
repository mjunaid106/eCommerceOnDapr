using Dapr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Services;

namespace Catalogue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPut]
        public async Task<Guid> Create([FromBody] Product.API.Models.Product product)
        {
            return await productService.CreateProductAsync(product);
        }

        [HttpGet]
        // Sample Product Id: 0c7e5eeb-29b8-4d54-a24d-3e8cb49c2d8d
        public async Task<Product.API.Models.Product> Get(Guid productId)
        {
            return await productService.GetProductAsync(productId);
        }

        //[Topic("pubsub", "neworder")]
        //[HttpPost("newproductorder")]
        //public void HandleProductOrder([FromBody] string order)
        //{
        //    Console.WriteLine("Subscriber received : " + order);
        //}
    }
}
